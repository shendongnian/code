            private void button1_Click(object sender, EventArgs e)
            {
    
                DataTable table = new DataTable();
                string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"",
                "C:\\Users\\Ryan\\Desktop\\Coding\\DOT.NET\\Samples C#\\Export DataGridView to SQL Server Table\\Import_List.xls");
                using (OleDbConnection dbConnection = new OleDbConnection(strConn))
                {
                    using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", dbConnection)) //rename sheet if required!
                        dbAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    int rows = table.Rows.Count;
                }
    
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns["FName"].DataPropertyName = table.Columns["FName"].ColumnName;
                dataGridView1.Columns["LName"].DataPropertyName = table.Columns["LName"].ColumnName;
                dataGridView1.Columns["Age"].DataPropertyName = table.Columns["Age"].ColumnName;
                dataGridView1.DataSource = table;
    
                //IF THE ORDER DOSEN'T MATTER
                //DataTable table = new DataTable();
                //string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", "C:\\Users\\Excel\\Desktop\\Coding\\DOT.NET\\Samples C#\\Export DataGridView to SQL Server Table\\Import_List.xls");
                //using (OleDbConnection dbConnection = new OleDbConnection(strConn))
                //{
                //    using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", dbConnection)) //rename sheet if required!
                //        dbAdapter.Fill(table);
                //    dataGridView1.DataSource = table;
                //    int rows = table.Rows.Count;
                //}
    
            }
