    private void bindToGrid(DataTable dtb)
    {   
        dataGridView1.DataSource = null;
        using (dtb)
        {
            dataGridView1.DataSource = dtb;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
    
            dataGridView1.Columns[0].Name = "PatientId";
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].DataPropertyName = "PatientId";
            //  more code here.
        }
    
        //DataGridViewLinkColumn EditLink = new DataGridViewLinkColumn();
        //EditLink.UseColumnTextForLinkValue = true;
        //EditLink.HeaderText = " Edit ";
        //EditLink.DataPropertyName = "lnkColumn";
        //EditLink.LinkBehavior = LinkBehavior.SystemDefault;
        //EditLink.Text = "Edit";
        //dataGridView1.Columns.Add(EditLink);
    }
