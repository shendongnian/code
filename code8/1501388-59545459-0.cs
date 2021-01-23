	Public Class DataGridViewDropDownComboBoxColumn
		Inherits DataGridViewColumn
		Public Sub New()
			MyBase.New(New DataGridViewDropDownComboBoxCell)
		End Sub
		Public Property DropDownStyle As ComboBoxStyle
		Public Property DataSource As Object
		Public Property ValueMember As Object
		Public Property DisplayMember As Object
		Public Overrides Property CellTemplate As DataGridViewCell
			Get
				Return MyBase.CellTemplate
			End Get
			Set
				' Ensure that the cell used for the template is a DataGridViewDropDownComboBoxCell.
				If ((Not (Value) Is Nothing) AndAlso Not Value.GetType.IsAssignableFrom(GetType(DataGridViewDropDownComboBoxCell))) Then
					Throw New InvalidCastException("Must be a DropDownCell")
				End If
				MyBase.CellTemplate = Value
			End Set
		End Property
	End Class
	Public Class DataGridViewDropDownComboBoxCell
		Inherits DataGridViewTextBoxCell
		Public Sub New()
			MyBase.New
		End Sub
		Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
			' Set the value of the editing control to the current cell value.
			MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
			Dim ctl As DataGridViewDropDownComboBoxEditingControl = CType(DataGridView.EditingControl, DataGridViewDropDownComboBoxEditingControl)
			' Use the default row value when Value property is null.
			If (Me.Value Is Nothing) Or IsDBNull(Me.Value) Then
				ctl.Text = CType(Me.DefaultNewRowValue, String)
			Else
				ctl.Text = CType(Me.Value, String)
			End If
			'ctl.BringToFront()
			'ctl.Focus()
			'ctl.DroppedDown = True
		End Sub
		Public Overrides ReadOnly Property EditType As Type
			Get
				' Return the type of the editing control that DataGridViewDropDownComboBoxCell uses.
				Return GetType(DataGridViewDropDownComboBoxEditingControl)
			End Get
		End Property
		Public Overrides ReadOnly Property ValueType As Type
			Get
				' Return the type of the value that DataGridViewDropDownComboBoxCell contains.
				Return GetType(String)
			End Get
		End Property
		Public Overrides ReadOnly Property DefaultNewRowValue As Object
			Get
				' Use the current date and time as the default value.
				Return ""
			End Get
		End Property
	End Class
	Class DataGridViewDropDownComboBoxEditingControl
		Inherits ComboBox
		Implements IDataGridViewEditingControl
		Private dataGridView As DataGridView
		Private valueChanged As Boolean = False
		Private rowIndex As Integer
		Public Sub New()
			MyBase.New
		End Sub
		Public Shadows Property DropDownStyle() As ComboBoxStyle
			Get
				Return MyBase.DropDownStyle
			End Get
			Set(ByVal value As ComboBoxStyle)
				If value = ComboBoxStyle.Simple Then
					'Throw New NotSupportedException("ComboBoxStyle.Simple not supported")
					value = ComboBoxStyle.DropDown
				End If
				MyBase.DropDownStyle = value
			End Set
		End Property
		' Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
		' property.
		Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
			Get
				Return Me.Text
			End Get
			Set
				If (TypeOf Value Is String) Then
					Me.Text = Value
				End If
			End Set
		End Property
		' Implements the 
		' IDataGridViewEditingControl.GetEditingControlFormattedValue method.
		Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
			Return Me.EditingControlFormattedValue
		End Function
		' Implements the 
		' IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
		Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
			Me.Font = dataGridViewCellStyle.Font
			Me.ForeColor = dataGridViewCellStyle.ForeColor
			Me.BackColor = dataGridViewCellStyle.BackColor
		End Sub
		' Implements the IDataGridViewEditingControl.EditingControlRowIndex 
		' property.
		Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
			Get
				Return Me.rowIndex
			End Get
			Set
				Me.rowIndex = Value
			End Set
		End Property
		' Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
		' method.
		Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
			' Let the DateTimePicker handle the keys listed.
			Select Case ((key And Keys.KeyCode))
				Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp, Keys.F4
					Return True
				Case Else
					Return Not dataGridViewWantsInputKey
			End Select
		End Function
		' Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
		' method.
		Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
			Dim col As DataGridViewDropDownComboBoxColumn = CType(dataGridView.Columns(dataGridView.CurrentCell.ColumnIndex), DataGridViewDropDownComboBoxColumn)
			If (col Is Nothing) Then
				Throw New InvalidCastException("Must be in a DropDownComboBoxColumn")
			End If
			DropDownStyle = col.DropDownStyle
			Items.Clear()
			If IsDBNull(dataGridView.CurrentCell.Value) Then
				Text = ""
			Else
				Text = CType(dataGridView.CurrentCell.Value, String)
			End If
			Items.Add(Text)
			Dim dt As DataTable = New DataTable
			Dim ct = 0, cx = 0
			Try
				dt = DirectCast(col.DataSource, DataTable)
				If Not col.DisplayMember Is Nothing Then
					For Each c As DataColumn In dt.Columns
						If c.ColumnName = col.DisplayMember Then
							cx = ct
						End If
						ct += 1
					Next
				End If
				For Each r As DataRow In dt.Rows
					If Not col.DisplayMember Is Nothing Then
						If Not Items.Contains(r(cx)) Then Items.Add(r(cx))
					Else
						If dt.Columns.Count = 1 Then
							If Not Items.Contains(r(0)) Then Items.Add(r(0))
						Else
							If Not Items.Contains(r(dt.Columns.Count - 1)) Then Items.Add(r(dt.Columns.Count - 1))
						End If
					End If
				Next
			Catch ex As Exception
			End Try
			'DropDownStyle = col.DropDownStyle
			'ValueMember = col.ValueMember
			'DisplayMember = col.DisplayMember
            'DataSource = col.DataSource
			' (If you don't explicitly set the Text then the current value is
			' always replaced with one from the drop-down list when edit begins.)
			'If IsDBNull(dataGridView.CurrentCell.Value) Then
			'    Text = ""
			'Else
			'    Text = CType(dataGridView.CurrentCell.Value, String)
			'End If
		End Sub
		' Implements the IDataGridViewEditingControl
		' .RepositionEditingControlOnValueChange property.
		Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
			Get
				Return False
			End Get
		End Property
		' Implements the IDataGridViewEditingControl
		' .EditingControlDataGridView property.
		Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
			Get
				Return Me.dataGridView
			End Get
			Set
				Me.dataGridView = Value
			End Set
		End Property
		' Implements the IDataGridViewEditingControl
		' .EditingControlValueChanged property.
		Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
			Get
				Return Me.valueChanged
			End Get
			Set
				Me.valueChanged = Value
			End Set
		End Property
		' Implements the IDataGridViewEditingControl
		' .EditingPanelCursor property.
		Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
			Get
				Return MyBase.Cursor
			End Get
		End Property
		Protected Overrides Sub OnTextChanged(ByVal eventargs As EventArgs)
			' Notify the DataGridView that the contents of the cell
			' have changed.
			Me.valueChanged = True
			Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
			MyBase.OnTextChanged(eventargs)
		End Sub
		Protected Overrides Sub OnSelectedIndexChanged(ByVal e As EventArgs)
			' Notify the DataGridView that the contents of the cell
			' have changed.
			Me.valueChanged = True
			Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
			MyBase.OnSelectedIndexChanged(e)
		End Sub
	End Class
