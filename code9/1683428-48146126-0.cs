    protected void btnValues_Click(object sender, EventArgs e)   
    {
        string strDDLValue = string.Empty;
        foreach (DropDownList ddl in pnlDepartment.Controls.OfType<DropDownList>())
        {
            strDDLValue = ddl.SelectedItem.Text
        }
    }  
