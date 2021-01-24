    Private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
                {
                    string filePath = openFileDialog1.FileName;
                    string extension = Path.GetExtension(filePath);
                    string header = rbHeaderYes.Checked ? "YES" : "NO";
                    string conStr, sheetName;
        
                    conStr = string.Empty;
                    switch (extension)
                    {
        
                        case ".xls": //Excel 97-03
                            conStr = string.Format(Excel03ConString, filePath, header);
                            break;
        
                        case ".xlsx": //Excel 07
                            conStr = string.Format(Excel07ConString, filePath, header);
                            break;
                    }
        
                    //Get the name of the First Sheet.
                    using (OleDbConnection con = new OleDbConnection(conStr))
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            cmd.Connection = con;
                            con.Open();
                            DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            con.Close();
                        }
                    }
        
                    //Read Data from the First Sheet.
                    using (OleDbConnection con = new OleDbConnection(conStr))
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            using (OleDbDataAdapter oda = new OleDbDataAdapter())
                            {
                                DataTable dt = new DataTable();
                                cmd.CommandText = "SELECT * From [" + sheetName + "]";
                                cmd.Connection = con;
                                con.Open();
                                oda.SelectCommand = cmd;
                                oda.Fill(dt);
                                sampleDatatable = dt;
                                con.Close();
                                dataGridView1.DataSource = dt;
        
        
        
                                //dataGridView2.DataSource = Headers;
        
                            }
                        }
                    }
           
     }
