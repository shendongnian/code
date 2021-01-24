        // Add a button column. 
        DataGridViewButtonColumn buttonColumn = 
            new DataGridViewButtonColumn();
        buttonColumn.HeaderText = "";
        buttonColumn.Name = "Status Request";
        buttonColumn.Text = "Request Status";
        buttonColumn.UseColumnTextForButtonValue = true;
        // Add a CellClick handler to handle clicks in the button column.
        dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["Status Request"].Index) return;
           ...... 
           you stuff....
       }
