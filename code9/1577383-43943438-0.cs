    Private Sub repositoryItemGridLookUpEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
                Dim editor As GridLookUpEdit = TryCast(sender, GridLookUpEdit)
                Dim index As Integer = editor.Properties.GetIndexByKeyValue(editor.EditValue)
                If index < 0 Then
                    Return
                End If
    
                Dim value As Object = (TryCast(editor.Properties.View.GetRow(index), DataRowView)).Row("Name")
                gridView2.SetFocusedRowCellValue("Name", value)
      End Sub
