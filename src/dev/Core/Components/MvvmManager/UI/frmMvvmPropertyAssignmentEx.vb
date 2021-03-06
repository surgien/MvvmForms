﻿'*****************************************************************************************
'                              frmMvvmPropertyAssignmentEx.vb
'                    =======================================================
'
'          Part of MvvmForms - The Component Library for bringing the Model-View-Viewmodel
'                              pattern to Data Centric Windows Forms Apps in an easy,
'                              feasible and XAML-compatible way.
'
'
'    This designer code is proprtiety code. A licence can be obtained - CONTACT INFO, see below.
'    Permission is granted, to use the designer code (in terms of running it for developing purposes)
'    to maintain Open Source Projects according to the OSI (opensource.org). For maintaining 
'    designer code in commercial (propriety) projects, a licence must be obtained.
'
'                       ActiveDevelop
'                       Bremer Str. 4
'                       Lippstadt, DE-59555
'                       Germany
'                       email: mvvmforms at activedevelop . de. 
'*****************************************************************************************

Imports System.Windows.Forms
Imports System.Collections.ObjectModel
Imports System.Threading.Tasks
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Data
Imports System.Runtime.CompilerServices

Public Class frmMvvmPropertyAssignmentEx

    Private myViewModelType As Type
    Private myControlToBind As Object

    Private myControlProperties As ObservableCollection(Of BindingProperty)
    Private myFlatViewModelProperties As ObservableCollection(Of BindingProperty)
    Private myTreeViewViewModelProperties As ObservableCollection(Of PropertyBindingNodeDefinition)

    Private myPropertyBindings As ObservableBindingList(Of PropertyBindingItem)
    Private myConverters As ObservableCollection(Of ConverterDisplayItem)

    Private myEventHandlerHaveBeenWired As Boolean
    Private myIsDirty As Boolean

    Property PropertyBindings As PropertyBindings
        Get
            Return New PropertyBindings(myPropertyBindings)
        End Get
        Set(value As PropertyBindings)
            If Not Object.Equals(value, myPropertyBindings) Then
                myPropertyBindings = value.ToObservableItemList
            End If
        End Set
    End Property

    Property AfterAddEditOrDeleteCallbackAction As Action

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        PopulateDisplayValues()
        Me.KeyPreview = True
    End Sub

    Public Sub PopulateDisplayValues()

        myViewModelType = If(Me.MvvmManager Is Nothing, Nothing, Me.MvvmManager.DataContextType)

        Dim viewName As String = myControlToBind.ToString()
        Dim control = TryCast(myControlToBind, Control)
        Dim viewType As String = "view"

        If control IsNot Nothing Then
            viewName = control.Name
            viewType = "control"
        End If

        If TypeOf myControlToBind Is MvvmDataGridColumn Then
            viewType = "column"
            'und das Label setzen (ist jetzt keine controlprop, sondern eine columnprop):
            lblControlProperty.Text = "Cell Property"
        End If

        lblCurrentControl.Text = If(myControlToBind Is Nothing, "Control", viewName)
        lblCurrentControlType.Text = If(myControlToBind Is Nothing, "(not set)", myControlToBind.GetType.Name & " " & viewType)

        If Me.EmbeddedMode Then
            Me.btnOK.Visible = False
        Else
            Me.btnOK.Visible = True
            If myViewModelType Is Nothing Then
                'Me.btnOK.Enabled = False
                Exit Sub
            End If
        End If

        lblCurrentViewModelType.Text = If(myViewModelType Is Nothing, "ViewModel Type", myViewModelType.Name)
        lblCurrentViewModelFullName.Text = If(myViewModelType Is Nothing, "(not set)", myViewModelType.FullName)

        InitializeConvertersSyncWorker()
        InitializeViewModelProperties()
        InitializeControlProperties()

        nvrControlProperties.DataSource = myControlProperties
        ViewModelPropertiesTreeView.DataSource = myTreeViewViewModelProperties
        If myTreeViewViewModelProperties IsNot Nothing Then
            ViewModelPropertyComboBox.NodesSource = New ObservableCollection(Of PropertyBindingNodeDefinition)(myTreeViewViewModelProperties)
        End If

        nvrConverters.DataSource = myConverters

        If Not myEventHandlerHaveBeenWired Then
            AddHandler PropertyBindingGrid.GridDataSource.CurrentChanged, AddressOf CurrentDataGridRowChanged

            AddHandler PropertyBindingGrid.AddButton.Click, AddressOf AddOrChangePropertyItemHandler
            AddHandler PropertyBindingGrid.ChangeButton.Click, AddressOf AddOrChangePropertyItemHandler

            AddHandler PropertyBindingGrid.DeleteButton.Click, AddressOf DeletePropertyItemHandler
            myEventHandlerHaveBeenWired = True
        End If

        If myPropertyBindings.Count > 0 Then
            Dim maxLvl = myPropertyBindings.Select(Function(b) b.ViewModelProperty.PropertyName.Count(Function(c) c = "."c)).Max()

            ViewModelPropertiesTreeView.LoadLevels(maxLvl)
        End If

        'Ganz zum Schluss erst Quelle binden, damit die Ereignisse, die das zur Folge hat, auch abgearbeitet werden.
        PropertyBindingGrid.GridDataSource.DataSource = IIf(myPropertyBindings IsNot Nothing AndAlso myPropertyBindings.Count > 0,
                                                            myPropertyBindings,
                                                            GetType(PropertyBindingItem))
        CurrentDataGridRowChanged(Nothing, EventArgs.Empty)
    End Sub

    Private Sub CurrentDataGridRowChanged(sender As Object, eventargs As EventArgs)

        Dim selectedPropBindingItem = DirectCast(PropertyBindingGrid.GridDataSource.Current, PropertyBindingItem)

        If selectedPropBindingItem IsNot Nothing Then
            Try
                nvrControlProperties.Value = selectedPropBindingItem.ControlProperty
            Catch ex As Exception
                MvvmFormsEtw.Log.Failure("INCONSISTENT PROPERTY MAPPING: While deserializing the property mapping from code (control property:  '" &
                            selectedPropBindingItem.ControlProperty.PropertyName & "'), the following exception occured:" & ex.Message)
            End Try

            Try
                nvrConverterParameter.Value = selectedPropBindingItem.ConverterParameter
                nvrConverters.Value = (From convItem In myConverters
                                       Where convItem.ConverterType Is selectedPropBindingItem.Converter).FirstOrDefault
            Catch ex As Exception
                MvvmFormsEtw.Log.Failure("INCONSISTENT PROPERTY MAPPING: While deserializing the property mapping from code (control property:  '" &
                            selectedPropBindingItem.Converter.ToString & "'), the following exception occured:" & ex.Message)
            End Try

            Try
                ViewModelPropertiesTreeView.SelectedItem = New PropertyBindingNodeDefinition(selectedPropBindingItem.ViewModelProperty)
            Catch ex As Exception
                MvvmFormsEtw.Log.Failure("INCONSISTENT PROPERTY MAPPING: While deserializing the property mapping from code (viewmodel property:  '" &
                            selectedPropBindingItem.ViewModelProperty.PropertyName & "'), the following exception occured:" & ex.Message)
            End Try
            BindingSettingPopup.BindingSetting = selectedPropBindingItem.BindingSetting
        End If

    End Sub

    Public Sub DeletePropertyItemHandler(sender As Object, e As EventArgs)
        If myPropertyBindings IsNot Nothing Then
            Dim bProperty = DirectCast(PropertyBindingGrid.GridDataSource.Current, PropertyBindingItem)
            myPropertyBindings.Remove(bProperty)
            Me.IsDirty = False
        End If
    End Sub

    Public Sub AddOrChangePropertyItemHandler(sender As Object, e As EventArgs)

        Dim ctrlProperty = DirectCast(nvrControlProperties.Value, BindingProperty)
        Dim vmProperty As BindingProperty = Nothing

        'Testen, ob die Daten vollständig erfasst wurden
        If nvrControlProperties.Value IsNot Nothing AndAlso ViewModelPropertiesTreeView.SelectedItem IsNot Nothing Then
            vmProperty = DirectCast(ViewModelPropertiesTreeView.SelectedItem, PropertyBindingNodeDefinition).Binding

            If nvrConverters.Value Is Nothing Then
                'Auf Typgleichheit prüfen, ansonsten Warnung ausgeben:
                If Not ctrlProperty.PropertyType.IsAssignableFrom(vmProperty.PropertyType) Then

                    'If Debugger.IsAttached Then
                    '    Debugger.Break()
                    'End If

                    Dim controlType = ctrlProperty.PropertyType

                    'Special case 1: We have a Nullable-Value on the control side. In this case, we're allow implicit conversion, and permit
                    'without warning, if the generic type parameter is of the same type than the VM Property type.
                    If controlType.IsGenericType AndAlso controlType.GetGenericTypeDefinition Is GetType(Nullable(Of )) Then
                        'We have to evaluate the first (and only, since it's a nullable) generic type arguments.
                        controlType = controlType.GetGenericArguments(0)
                    End If

                    'Special case 2: StringValue a control and String in a VM is OK, because it will be tolerated by the BindingEngine.
                    If (GetType(StringValue).IsAssignableFrom(controlType) And GetType(String).IsAssignableFrom(vmProperty.PropertyType)) Then
                        GoTo skipWarning
                    End If

                    'Special case: StringValue a control and String in a VM is OK, because it will be tolerated by the BindingEngine.
                    Dim dr = MessageBox.Show("The type of the control property and the view model property does not match." & vbNewLine &
                                "You should consider to either use matching types for the properties or implement a type converter," & vbNewLine &
                                "to equalize the types, which you can later choose here from the Converter combobox.",
                                "Types do not match:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    If dr = System.Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If
skipWarning:
                End If
            End If
        Else
            Return
        End If

        If myPropertyBindings Is Nothing Then
            myPropertyBindings = New ObservableBindingList(Of PropertyBindingItem)
        End If

        If DirectCast(sender, ToolStripButton).Name = "AddToolStripButton" Then

            Dim bProperty As New PropertyBindingItem() With
                    {.ControlProperty = ctrlProperty,
                     .ViewModelProperty = vmProperty,
                     .Converter = If(nvrConverters.Value Is Nothing, Nothing, DirectCast(nvrConverters.Value, ConverterDisplayItem).ConverterType),
                     .ConverterParameter = If(nvrConverterParameter.Value.HasValue, nvrConverterParameter.Value.Value, Nothing),
                     .BindingSetting = BindingSettingPopup.BindingSetting}

            myPropertyBindings.Add(bProperty)
            If PropertyBindingGrid.GridDataSource.DataSource IsNot myPropertyBindings Then
                PropertyBindingGrid.GridDataSource.DataSource = myPropertyBindings
            End If
        Else
            Dim bProperty = DirectCast(PropertyBindingGrid.GridDataSource.Current, PropertyBindingItem)
            With bProperty
                .ControlProperty = ctrlProperty
                .ViewModelProperty = vmProperty
                .Converter = If(nvrConverters.Value Is Nothing, Nothing, DirectCast(nvrConverters.Value, ConverterDisplayItem).ConverterType)
                .ConverterParameter = If(nvrConverterParameter.Value.HasValue, nvrConverterParameter.Value.Value, Nothing)
                .BindingSetting = BindingSettingPopup.BindingSetting
            End With
            PropertyBindingGrid.GridDataSource.ResetCurrentItem()
        End If
        If AfterAddEditOrDeleteCallbackAction IsNot Nothing Then
            AfterAddEditOrDeleteCallbackAction.Invoke()
        End If
        IsDirty = False
    End Sub

    Private Sub InitializeConvertersSyncWorker()

        Dim messageBoxContent As String = ""

        Try
            Dim tmpConverterlist As New List(Of ConverterDisplayItem)
            Dim convs = TypeDiscoveryService.GetTypes(GetType(IValueConverter), False)

            For Each item In convs
                Dim typeItem = DirectCast(item, System.Type)
                Dim tmpConverterDisplayItem = New ConverterDisplayItem With {
                                    .ConverterName = typeItem.Name,
                                    .ConverterAssembly = typeItem.Assembly.ToString,
                                    .ConverterType = typeItem}
                Dim addIt = Not typeItem.IsInterface AndAlso Not typeItem.IsAbstract
                If addIt Then
                    addIt = Not typeItem.FullName.StartsWith("MS.Internal.")
                End If

                If addIt Then
                    tmpConverterlist.Add(tmpConverterDisplayItem)
                End If
            Next

            myConverters = New ObservableCollection(Of ConverterDisplayItem)((
                    From retListItems In tmpConverterlist Order By retListItems.ConverterName).ToList)
        Catch ex As Exception
            MessageBox.Show("Error in Handling:" & vbNewLine & ex.Message & vbNewLine & vbNewLine & messageBoxContent, "Not wanted:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub InitializeControlProperties()
        If myControlToBind Is Nothing Then
            myControlProperties = New ObservableCollection(Of BindingProperty)
            Return
        End If

        Try
            myControlProperties = New ObservableCollection(Of BindingProperty)(
                (From methodItem In myControlToBind.GetType.GetMethods(Reflection.BindingFlags.NonPublic Or
                                                                     Reflection.BindingFlags.Public Or
                                                                     Reflection.BindingFlags.Instance)
                 Where methodItem.Name.StartsWith("On") And methodItem.Name.EndsWith("Changed")
                 Join propItem In myControlToBind.GetType.GetProperties(Reflection.BindingFlags.NonPublic Or
                                                                    Reflection.BindingFlags.Public Or
                                                                    Reflection.BindingFlags.Instance) On
                            methodItem.Name.Substring(2, methodItem.Name.Length - 9).ToUpper Equals propItem.Name.ToUpper
                 Order By propItem.Name
                 Select New BindingProperty With
                {.PropertyName = propItem.Name,
                 .PropertyType = propItem.PropertyType}))
        Catch ex As Exception
            MessageBox.Show("Error in Handling:" & vbNewLine & ex.Message &
                            vbNewLine & vbNewLine & ex.StackTrace, "Not wanted:",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub InitializeViewModelProperties()
        'If Debugger.IsAttached Then
        '    Debugger.Break()
        'End If

        If myViewModelType Is Nothing Then
            myFlatViewModelProperties = New ObservableCollection(Of BindingProperty)
            Return
        End If

        Try
            Dim attList = From attItem In myViewModelType.GetCustomAttributes(True)
                          Where GetType(BusinessClassAttribute).IsAssignableFrom(attItem.GetType) Or
                          GetType(MvvmViewModelAttribute).IsAssignableFrom(attItem.GetType)

            If attList IsNot Nothing Then

                Dim businessClassAtt = (From bcaItem In attList Where GetType(BusinessClassAttribute).IsAssignableFrom(bcaItem.GetType)).SingleOrDefault

                'Legacy-Info (DE-Projects only): Das ViewModel-Attribute brauchen wir in diesem Kontext eigentlich nicht mehr.
                'Bis Februar 2014 war es erforderlich, ein ViewModel mit dem MvvmViewModel-Attribute auszuzeichnen,
                'dass es in der Typauflistung erschien - nunmehr reicht es, wenn eine Klasse INotifyPropertyChanged implementiert.
                'Deswegen ist es hier aber ebenfalls notwendig, eine entsprechende Änderung zu machen, sodass, wenn keine 
                'Attribut-Auszeichnung über der Klasse steht, an dieser Stelle die Klasse als ViewModel incl. aller ihrer
                'Eigenschaften berücksichtigt wird.
                Dim viemModelAtt = (From bcaItem In attList Where GetType(MvvmViewModelAttribute).IsAssignableFrom(bcaItem.GetType)).SingleOrDefault

                If (businessClassAtt IsNot Nothing AndAlso
                    DirectCast(businessClassAtt, BusinessClassAttribute).Options.
                        HasFlag(BusinessClassAttributeOptions.IncludeAllPropertiesByDefault)) Or
                            businessClassAtt Is Nothing Then

                    'Include bei Default.
                    Dim propertiesList = New List(Of PropertyCheckBoxItemController)
                    ReflectionHelper.CreateFlatSubPropAsList(myViewModelType, "", propertiesList, False)

                    myFlatViewModelProperties = New ObservableCollection(Of BindingProperty)(
                        From pItem In propertiesList
                        Order By pItem.PropertyFullname
                        Select New BindingProperty With
                        {.PropertyName = pItem.PropertyFullname,
                         .PropertyType = pItem.PropertyType})

                ElseIf (businessClassAtt IsNot Nothing) AndAlso
                    (DirectCast(businessClassAtt, BusinessClassAttribute).Options.HasFlag(BusinessClassAttributeOptions.ExcludeAllPropertiesByDefault)) AndAlso viemModelAtt Is Nothing Then

                    'Exclude bei Default
                    Dim propertiesList = New List(Of PropertyCheckBoxItemController)
                    ReflectionHelper.CreateFlatSubPropAsList(myViewModelType, "", propertiesList, True)

                    myFlatViewModelProperties = New ObservableCollection(Of BindingProperty)(
                        From pItem In propertiesList
                        Order By pItem.PropertyFullname
                        Select New BindingProperty With
                        {.PropertyName = pItem.PropertyFullname,
                         .PropertyType = pItem.PropertyType})
                End If

                myTreeViewViewModelProperties = New ObservableCollection(Of PropertyBindingNodeDefinition)()

                'Create List for TreeView
                For Each binding In myFlatViewModelProperties
                    myTreeViewViewModelProperties.Add(New PropertyBindingNodeDefinition() With {.Binding = binding, .PropertyName = binding.PropertyName})
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error in Handling:" & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, "Not wanted:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ''' Hier wird das Control gespeichert, welches von diesem Formular als Bindungselement verwendet wird.
    Friend Property ControlToBind As Object
        Get
            Return myControlToBind
        End Get
        Set(value As Object)
            If Not Object.Equals(myControlToBind, value) Then
                myControlToBind = value
            End If
            OnControlToAssignChanged()
        End Set
    End Property

    Protected Overridable Sub OnControlToAssignChanged()
        PopulateDisplayValues()
    End Sub

    Friend Property MvvmManager As IMvvmManager
    Friend Property DesignerHost As IDesignerHost
    Friend Property ComponentDesigner As MvvmManagerDesigner
    Friend Property DesignTimeAssemblyLoader As IDesignTimeAssemblyLoader
    Friend Property ReferenceService As IReferenceService
    Friend Property TypeDiscoveryService As ITypeDiscoveryService

    Friend Property EmbeddedMode As Boolean

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Protected Overrides Sub OnClosing(e As CancelEventArgs)
        MyBase.OnClosing(e)

        If Debugger.IsAttached Then
            Debugger.Break()
        End If

        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            If IsDirty Then
                Dim dr = MessageBox.Show("Do you want to discard your pending changes?",
                                 "Pending changes",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                e.Cancel = (dr = DialogResult.No)
            End If
        End If
    End Sub

    Sub CommitChanges()
    End Sub

    Sub IgnoreChanges()
    End Sub

    Private Sub frmMvvmPropertyAssignment_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Control.ModifierKeys = (Keys.Alt Or Keys.Shift Or Keys.Control) Then
            If Debugger.IsAttached Then
                Debugger.Break()
            End If
        End If
    End Sub

    Private Sub ViewModelPropertiesTreeView_SelectedItemChanged(sender As Object, e As EventArgs) Handles ViewModelPropertiesTreeView.SelectedItemChanged
        ViewModelPropertyComboBox.SelectedNode = DirectCast(ViewModelPropertiesTreeView.SelectedItem, PropertyBindingNodeDefinition)
    End Sub

    Private Sub ViewModelPropertyComboBox_SelectedItemChanged(sender As Object, e As EventArgs) Handles ViewModelPropertyComboBox.SelectedItemChanged
        'TODO: Load Tree only selective (via Path)!
        If ViewModelPropertyComboBox.SelectedNode.Binding.PropertyName.Contains("."c) Then
            ViewModelPropertiesTreeView.LoadLevels(ViewModelPropertyComboBox.SelectedNode.Binding.PropertyName.Count(Function(c) c = "."c))
        End If

        ViewModelPropertiesTreeView.SelectedItem = ViewModelPropertyComboBox.SelectedNode
    End Sub

    Friend Property IsDirty As Boolean
        Get
            Return myIsDirty
        End Get
        Set(value As Boolean)
            If Not Object.Equals(myIsDirty, value) Then

                If Debugger.IsAttached Then
                    Debugger.Break()
                End If

                myIsDirty = value
                If Not value Then
                    ViewModelPropertiesTreeView.ResetIsDirty()
                    nvrControlProperties.ResetIsDirty()
                    nvrControlProperties.ResetIsDirty()
                    nvrConverterParameter.ResetIsDirty()
                End If
            End If
        End Set
    End Property

    Private Sub ViewModelPropertiesTreeView_IsDirtyChanged(sender As Object, e As IsDirtyChangedEventArgs) Handles ViewModelPropertiesTreeView.IsDirtyChanged,
                                                                                                                    nvrControlProperties.IsDirtyChanged,
                                                                                                                    nvrConverters.IsDirtyChanged,
                                                                                                                    nvrConverterParameter.IsDirtyChanged
        Me.IsDirty = Me.IsDirty Or DirectCast(e.CausingControl, IIsDirtyChangedAware).IsDirty
    End Sub

    Private Sub BindingSettingPopup_BindingSettingChanged(sender As Object, e As EventArgs) Handles BindingSettingPopup.BindingSettingChanged
        Me.IsDirty = True
    End Sub
End Class

