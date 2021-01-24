    Protected Sub rptForms_ItemDataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptForms.ItemDataBound
        Dim lblForm As HtmlGenericControl = CType(e.Item.FindControl("lblForm"), HtmlGenericControl)
        Dim cb As HtmlInputCheckBox = CType(e.Item.FindControl("cbForm"), HtmlInputCheckBox)
        lblForm.Attributes.Item("for") = cb.ClientID
    End Sub
