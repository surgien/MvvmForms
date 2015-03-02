﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMvvmPropertyAssignment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                myConverters = Nothing
                myControlProperties = Nothing
                myViewModelProperties = Nothing

                RemoveHandler PropertyBindingGrid.GridDataSource.CurrentChanged, AddressOf CurrentDataGridRowChanged
                RemoveHandler PropertyBindingGrid.AddButton.Click, AddressOf AddOrChangePropertyItemHandler
                RemoveHandler PropertyBindingGrid.ChangeButton.Click, AddressOf AddOrChangePropertyItemHandler
                RemoveHandler PropertyBindingGrid.DeleteButton.Click, AddressOf DeletePropertyItemHandler
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblControlProperty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.nvrControlProperties = New ActiveDevelop.EntitiesFormsLib.NullableValueRelationPopup()
        Me.nvrViewModelProperty = New ActiveDevelop.EntitiesFormsLib.NullableValueRelationPopup()
        Me.PropertyBindingGrid = New ActiveDevelop.EntitiesFormsLib.ControlBindingGrid()
        Me.BindingSettingPopup = New ActiveDevelop.EntitiesFormsLib.BindingSettingPopup()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.nvrConverterParameter = New ActiveDevelop.EntitiesFormsLib.NullableTextValue()
        Me.nvrConverters = New ActiveDevelop.EntitiesFormsLib.NullableValueRelationPopup()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCurrentViewModelType = New System.Windows.Forms.Label()
        Me.lblCurrentViewModelFullName = New System.Windows.Forms.Label()
        Me.lblCurrentControl = New System.Windows.Forms.Label()
        Me.lblCurrentControlType = New System.Windows.Forms.Label()
        Me.FormToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.nvrControlProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nvrViewModelProperty,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        CType(Me.nvrConverters,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel2.SuspendLayout
        Me.SuspendLayout
        '
        'lblControlProperty
        '
        Me.lblControlProperty.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblControlProperty.AutoSize = true
        Me.lblControlProperty.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblControlProperty.Location = New System.Drawing.Point(0, 11)
        Me.lblControlProperty.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblControlProperty.Name = "lblControlProperty"
        Me.lblControlProperty.Size = New System.Drawing.Size(117, 13)
        Me.lblControlProperty.TabIndex = 0
        Me.lblControlProperty.Text = "Control Property"
        Me.lblControlProperty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 26)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Converter"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(Parameter)"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(411, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "View model property"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(411, 63)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Binding mode"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53!))
        Me.TableLayoutPanel1.Controls.Add(Me.nvrControlProperties, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.nvrViewModelProperty, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PropertyBindingGrid, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblControlProperty, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BindingSettingPopup, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 107)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(875, 496)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'nvrControlProperties
        '
        Me.nvrControlProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.nvrControlProperties.AssignedManagerComponent = Nothing
        Me.nvrControlProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.nvrControlProperties.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.nvrControlProperties.BeepOnFailedValidation = false
        Me.nvrControlProperties.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nvrControlProperties.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.nvrControlProperties.DataSource = Nothing
        Me.nvrControlProperties.DisplayMember = """{0}"", {PropertyName}"
        Me.nvrControlProperties.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.nvrControlProperties.HideButtons = false
        Me.nvrControlProperties.IsPopupAutoSize = false
        Me.nvrControlProperties.IsPopupResizable = true
        Me.nvrControlProperties.Location = New System.Drawing.Point(123, 6)
        Me.nvrControlProperties.MinimumPopupSize = New System.Drawing.Size(285, 80)
        Me.nvrControlProperties.MultiSelect = false
        Me.nvrControlProperties.Name = "nvrControlProperties"
        Me.nvrControlProperties.NullValueString = "* - - - *"
        Me.nvrControlProperties.PermissionReason = Nothing
        Me.nvrControlProperties.PreferredVisibleColumnsOnOpen = 2
        Me.nvrControlProperties.PreferredVisibleRowsOnOpen = 10
        Me.nvrControlProperties.ReverseTextOverflowBehaviour = true
        Me.nvrControlProperties.Searchable = true
        Me.nvrControlProperties.SearchColumnHeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.nvrControlProperties.Size = New System.Drawing.Size(285, 22)
        Me.nvrControlProperties.TabIndex = 1
        Me.nvrControlProperties.UIGuid = New System.Guid("7b05d4b5-998f-4216-ae43-12e7bd51942c")
        Me.nvrControlProperties.ValueMember = Nothing
        '
        'nvrViewModelProperty
        '
        Me.nvrViewModelProperty.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.nvrViewModelProperty.AssignedManagerComponent = Nothing
        Me.nvrViewModelProperty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.nvrViewModelProperty.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.nvrViewModelProperty.BeepOnFailedValidation = false
        Me.nvrViewModelProperty.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nvrViewModelProperty.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.nvrViewModelProperty.DataSource = Nothing
        Me.nvrViewModelProperty.DisplayMember = """{0}"", {PropertyName}"
        Me.nvrViewModelProperty.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.nvrViewModelProperty.HideButtons = false
        Me.nvrViewModelProperty.IsPopupAutoSize = false
        Me.nvrViewModelProperty.IsPopupResizable = true
        Me.nvrViewModelProperty.Location = New System.Drawing.Point(549, 6)
        Me.nvrViewModelProperty.MinimumPopupSize = New System.Drawing.Size(323, 80)
        Me.nvrViewModelProperty.MultiSelect = false
        Me.nvrViewModelProperty.Name = "nvrViewModelProperty"
        Me.nvrViewModelProperty.NullValueString = "* - - - *"
        Me.nvrViewModelProperty.PermissionReason = Nothing
        Me.nvrViewModelProperty.PreferredVisibleColumnsOnOpen = 2
        Me.nvrViewModelProperty.PreferredVisibleRowsOnOpen = 10
        Me.nvrViewModelProperty.ReverseTextOverflowBehaviour = true
        Me.nvrViewModelProperty.Searchable = true
        Me.nvrViewModelProperty.SearchColumnHeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.nvrViewModelProperty.Size = New System.Drawing.Size(323, 22)
        Me.nvrViewModelProperty.TabIndex = 3
        Me.nvrViewModelProperty.UIGuid = New System.Guid("7b05d4b5-998f-4216-ae43-12e7bd51942c")
        Me.nvrViewModelProperty.ValueMember = Nothing
        '
        'PropertyBindingGrid
        '
        Me.PropertyBindingGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.PropertyBindingGrid, 4)
        Me.PropertyBindingGrid.Location = New System.Drawing.Point(3, 113)
        Me.PropertyBindingGrid.Margin = New System.Windows.Forms.Padding(3, 8, 3, 5)
        Me.PropertyBindingGrid.Name = "PropertyBindingGrid"
        Me.PropertyBindingGrid.Size = New System.Drawing.Size(869, 378)
        Me.PropertyBindingGrid.TabIndex = 7
        '
        'BindingSettingPopup
        '
        Me.BindingSettingPopup.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.BindingSettingPopup.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BindingSettingPopup.HideButtons = false
        Me.BindingSettingPopup.Location = New System.Drawing.Point(549, 60)
        Me.BindingSettingPopup.Name = "BindingSettingPopup"
        Me.BindingSettingPopup.Size = New System.Drawing.Size(323, 20)
        Me.BindingSettingPopup.TabIndex = 6
        Me.BindingSettingPopup.Text = "TwoWay on LostFocus"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.nvrConverterParameter)
        Me.Panel1.Controls.Add(Me.nvrConverters)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(123, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(285, 64)
        Me.Panel1.TabIndex = 19
        '
        'nvrConverterParameter
        '
        Me.nvrConverterParameter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.nvrConverterParameter.AssignedManagerComponent = Nothing
        Me.nvrConverterParameter.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nvrConverterParameter.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.nvrConverterParameter.Location = New System.Drawing.Point(0, 33)
        Me.nvrConverterParameter.MaxLength = 32767
        Me.nvrConverterParameter.Name = "nvrConverterParameter"
        Me.nvrConverterParameter.ObfuscationChar = Nothing
        Me.nvrConverterParameter.PermissionReason = Nothing
        Me.nvrConverterParameter.Size = New System.Drawing.Size(285, 22)
        Me.nvrConverterParameter.TabIndex = 1
        Me.nvrConverterParameter.UIGuid = New System.Guid("23ef76aa-2b5f-4314-988d-38992f5d4564")
        Me.nvrConverterParameter.Value = Nothing
        Me.nvrConverterParameter.ValueValidationState = Nothing
        '
        'nvrConverters
        '
        Me.nvrConverters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.nvrConverters.AssignedManagerComponent = Nothing
        Me.nvrConverters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.nvrConverters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.nvrConverters.BeepOnFailedValidation = false
        Me.nvrConverters.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nvrConverters.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal
        Me.nvrConverters.DataSource = Nothing
        Me.nvrConverters.DisplayMember = """{0}"" ,ConverterName"
        Me.nvrConverters.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.nvrConverters.HideButtons = false
        Me.nvrConverters.IsPopupAutoSize = false
        Me.nvrConverters.IsPopupResizable = true
        Me.nvrConverters.Location = New System.Drawing.Point(0, 8)
        Me.nvrConverters.MinimumPopupSize = New System.Drawing.Size(285, 80)
        Me.nvrConverters.MultiSelect = false
        Me.nvrConverters.Name = "nvrConverters"
        Me.nvrConverters.NullValueString = "* - - - *"
        Me.nvrConverters.PermissionReason = Nothing
        Me.nvrConverters.PreferredVisibleColumnsOnOpen = 2
        Me.nvrConverters.PreferredVisibleRowsOnOpen = 10
        Me.nvrConverters.ReverseTextOverflowBehaviour = true
        Me.nvrConverters.Searchable = true
        Me.nvrConverters.SearchColumnHeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.nvrConverters.Size = New System.Drawing.Size(285, 22)
        Me.nvrConverters.TabIndex = 0
        Me.nvrConverters.UIGuid = New System.Guid("7b05d4b5-998f-4216-ae43-12e7bd51942c")
        Me.nvrConverters.ValueMember = Nothing
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.8217!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.1783!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblCurrentViewModelType, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCurrentViewModelFullName, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCurrentControl, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCurrentControlType, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.84615!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.15385!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(875, 84)
        Me.TableLayoutPanel2.TabIndex = 17
        '
        'lblCurrentViewModelType
        '
        Me.lblCurrentViewModelType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCurrentViewModelType.AutoEllipsis = true
        Me.lblCurrentViewModelType.AutoSize = true
        Me.lblCurrentViewModelType.Font = New System.Drawing.Font("Segoe UI", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCurrentViewModelType.Location = New System.Drawing.Point(412, 40)
        Me.lblCurrentViewModelType.Name = "lblCurrentViewModelType"
        Me.lblCurrentViewModelType.Size = New System.Drawing.Size(123, 32)
        Me.lblCurrentViewModelType.TabIndex = 3
        Me.lblCurrentViewModelType.Text = "- not set -"
        '
        'lblCurrentViewModelFullName
        '
        Me.lblCurrentViewModelFullName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCurrentViewModelFullName.AutoEllipsis = true
        Me.lblCurrentViewModelFullName.AutoSize = true
        Me.lblCurrentViewModelFullName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCurrentViewModelFullName.Location = New System.Drawing.Point(419, 5)
        Me.lblCurrentViewModelFullName.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.lblCurrentViewModelFullName.Name = "lblCurrentViewModelFullName"
        Me.lblCurrentViewModelFullName.Size = New System.Drawing.Size(320, 17)
        Me.lblCurrentViewModelFullName.TabIndex = 2
        Me.lblCurrentViewModelFullName.Text = "Set the MVVM-Manager's DataContextType property."
        '
        'lblCurrentControl
        '
        Me.lblCurrentControl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCurrentControl.AutoEllipsis = true
        Me.lblCurrentControl.AutoSize = true
        Me.lblCurrentControl.Font = New System.Drawing.Font("Segoe UI", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCurrentControl.Location = New System.Drawing.Point(3, 40)
        Me.lblCurrentControl.Name = "lblCurrentControl"
        Me.lblCurrentControl.Size = New System.Drawing.Size(94, 32)
        Me.lblCurrentControl.TabIndex = 1
        Me.lblCurrentControl.Text = "Control"
        '
        'lblCurrentControlType
        '
        Me.lblCurrentControlType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCurrentControlType.AutoEllipsis = true
        Me.lblCurrentControlType.AutoSize = true
        Me.lblCurrentControlType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCurrentControlType.Location = New System.Drawing.Point(10, 5)
        Me.lblCurrentControlType.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.lblCurrentControlType.Name = "lblCurrentControlType"
        Me.lblCurrentControlType.Size = New System.Drawing.Size(80, 17)
        Me.lblCurrentControlType.TabIndex = 0
        Me.lblCurrentControlType.Text = "Control type"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(772, 617)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(115, 35)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(13, 618)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(523, 33)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Note: If you implement an IValueConvert for the Value property of a NullableValue"& _ 
    "Text control, please remember to return StringValue and not String as the Conver"& _ 
    "t method's Data Type."
        '
        'frmMvvmPropertyAssignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 666)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MinimumSize = New System.Drawing.Size(560, 400)
        Me.Name = "frmMvvmPropertyAssignment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mvvm Property Assignment"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        CType(Me.nvrControlProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nvrViewModelProperty,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        CType(Me.nvrConverters,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents nvrControlProperties As ActiveDevelop.EntitiesFormsLib.NullableValueRelationPopup
    Friend WithEvents lblControlProperty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nvrViewModelProperty As ActiveDevelop.EntitiesFormsLib.NullableValueRelationPopup
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PropertyBindingGrid As ActiveDevelop.EntitiesFormsLib.ControlBindingGrid
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCurrentViewModelType As System.Windows.Forms.Label
    Friend WithEvents lblCurrentControl As System.Windows.Forms.Label
    Friend WithEvents FormToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents BindingSettingPopup As ActiveDevelop.EntitiesFormsLib.BindingSettingPopup
    Friend WithEvents lblCurrentControlType As System.Windows.Forms.Label
    Friend WithEvents lblCurrentViewModelFullName As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents nvrConverterParameter As ActiveDevelop.EntitiesFormsLib.NullableTextValue
    Friend WithEvents nvrConverters As ActiveDevelop.EntitiesFormsLib.NullableValueRelationPopup
    Friend WithEvents Label1 As Windows.Forms.Label
End Class