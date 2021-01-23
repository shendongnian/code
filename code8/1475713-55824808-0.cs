    protected void grdResults_OnPreRender(object sender, EventArgs e)
    {
        TemplateField FieldToAccess= grdResults.Columns.OfType<TemplateField> 
                                     ().Where(f => f.HeaderText == 
                                     "ValidityDate").FirstOrDefault();
        if (role)
        FieldToAccess.Visible = false;
    }
