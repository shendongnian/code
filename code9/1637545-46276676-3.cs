        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim gvRow As GridViewRow = GridView1.Rows(index)
            Dim lnkbtn As LinkButton = CType(GridViewRow.FindControl("linkbuttonID"), LinkButton)
            //... here some logic
        End Sub
