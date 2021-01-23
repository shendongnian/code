    Protected Sub dgGlossaries_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGlossaries.DeleteCommand
        Dim rowToDelete = e.Item.ItemIndex
        Dim dt As DataTable = DirectCast(Session("glossaries"), DataTable)
        Dim dr As DataRow = dt.Rows(rowToDelete)
        dr.Delete()
        dgGlossaries.DataSource = dt
        dgGlossaries.DataBind()
    End Sub
