     public void LoadDataGrid(DataTable d, DataGridView dg )
        {
           
            if (dg.InvokeRequired)
            {
                dg.BeginInvoke((MethodInvoker)delegate()
                {
                    dg.Rows.Clear();
                    dg.ColumnCount = 7;
                    dg.Columns[0].Name = "Order No.";
                    dg.Columns[0].Width = 110;
                    dg.Columns[1].Name = "Order Date";
                    dg.Columns[1].Width = 100;
                    dg.Columns[2].Name = "Excepted rcv date";
                    dg.Columns[2].Width = 100;
                    dg.Columns[3].Name = "Supplier";
                    dg.Columns[3].Width = 150;
                    dg.Columns[4].Name = "Total Items";
                    dg.Columns[4].Width = 80;
                    dg.Columns[5].Name = "Total";
                    dg.Columns[5].Width = 80;
                    dg.Columns[6].Name = "Status";
                    dg.Columns[6].Width = 100;
                    
                    
                });
                foreach (DataRow row in d.Rows)
                {
                   
                    if (dg.InvokeRequired)
                    {
                        dg.BeginInvoke((MethodInvoker)delegate() { dg.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString()); });
                    }
                      
                         
                        Thread.Sleep(100);
                    }
                }
            
        }
