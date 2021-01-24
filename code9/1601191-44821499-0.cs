                    DataTable dt = new DataTable();
                    dt.Columns.Add("Date", typeof(DateTime));
                    dt.Columns.Add("Particular", typeof(string));
                    dt.Columns.Add("Debit", typeof(int));
                    dt.Columns.Add("Credit", typeof(int));
                    dt.Columns.Add("Balance", typeof(string));
                    dt.Columns.Add("Summary", typeof(string));
    
    
            private void bindGridtoDataTable()
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    dt.Rows.Add(row.Cells["Date"].Value, row.Cells["Particular"].Value, row.Cells["Debit"].Value, row.Cells["Credit"].Value, row.Cells["Balance"].Value, row.Cells["Summary"].Value);
            }
