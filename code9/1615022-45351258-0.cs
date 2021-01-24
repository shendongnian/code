             DataTable table = new DataTable();
             if(table.Rows.Count==0)
                {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                }
             //if you already know the column of the table    
             table.Columns.Add("sl.No", typeof(int));
             table.Columns.Add("Name", typeof(string));
    
            // Here we add a DataRow.
            table.Rows.Add(57, "Amin");
