    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As DataListItemEventArgs)
        'find the button in the datalist item object and cast it back to one
        Dim button As Button = CType(e.Item.FindControl("Button1"),Button)
        'you can now access it's properties
        button.BackColor = Color.Red
    End Sub
