    private void frmPatientList_Shown(object sender, EventArgs e)
    {
        DataGridViewLinkColumn EditLink = new DataGridViewLinkColumn();
        EditLink.UseColumnTextForLinkValue = true;
        EditLink.HeaderText = " Edit ";
        EditLink.DataPropertyName = "lnkColumn";
        EditLink.LinkBehavior = LinkBehavior.SystemDefault;
        EditLink.Text = "Edit";
        dataGridView1.Columns.Add(EditLink);
    
        loadPatientList();
    }
