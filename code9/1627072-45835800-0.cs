            Private Sub DataGridView_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView.EditingControlShowing
                    'Route the event depending the cells being edited
                    Try
                        If Me.DataGridView.CurrentCell.OwningColumn Is Me.DataGridView.Columns("comboboxcolumnname") Then
                            comboboxcolumnname_EditingControlShowing(sender, e)
                        End If
                    Catch ex As Exception
        'Exception handling...
                    End Try
                End Sub
    
        Private Sub comboboxcolumnname_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
            Dim editor As ComboBox = CType(e.Control, ComboBox)
            Dim currentKey As Short = Me.DataGridView.CurrentRow.Cells("comboboxcolumnname").Value
    
            'Filter editor datasource, remove inactives items except current
            Dim listObject As New List(Of Object)
            listObject.AddRange(GlobalList.Where(Function(c) c.FilterCondition = True OrElse c.ID = currentKey).OrderBy(Function(c) c.Name))
            editor.DataSource = listObject
    
            editor.SelectedValue = currentKey
    
            'Adapt the width of the DropDown
            CType(Me.DataGridView.Columns("comboboxcolumnname"), DataGridViewComboBoxColumn).FixupDropDownWidth(listObject)
        End Sub
    
     <Extension()>
        Public Sub FixupDropDownWidth(column As DataGridViewComboBoxColumn, items As IEnumerable)
            Dim width As Integer = column.DropDownWidth
    
            Dim vertScrollBarWidth As Integer = 0
            If column.Items.Count > column.MaxDropDownItems Then vertScrollBarWidth = SystemInformation.VerticalScrollBarWidth
    
            Dim g As Graphics = column.DataGridView.CreateGraphics()
            Dim font As Font
    
            font = column.DefaultCellStyle.Font
            If font Is Nothing Then font = column.DataGridView.Font
    
            Dim maxWidth As Integer = 0
            For Each item In items
                Dim stringValue As String
                If item.GetType.GetProperty(column.DisplayMember) IsNot Nothing Then
                    stringValue = CStr(item.GetType().GetProperty(column.DisplayMember).GetValue(item, Nothing))
                Else
                    stringValue = item.ToString
                End If
                maxWidth = g.MeasureString(CStr(stringValue), font).Width + vertScrollBarWidth
                If width < maxWidth Then width = maxWidth
            Next
    
            column.DropDownWidth = width
        End Sub
