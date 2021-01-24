        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim gvRow As GridViewRow = GridView1.Rows(index) // find GridView clicked row
            // find LinkButton from GridView row
            Dim LinkButton1 As LinkButton = CType(GridViewRow.FindControl("LinkButton1"), LinkButton)
            //... here some logic
        End Sub
