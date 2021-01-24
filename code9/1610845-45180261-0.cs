    try
                {
                    this.txtImportFilePath.Text = opd.FileName;
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + this.txtImportFilePath.Text + ";Extended Properties=Excel 8.0;");
                    StringBuilder stbQuery = new StringBuilder();
                    stbQuery.Append("Select * From [Sheet1$]");
                    OleDbDataAdapter adp = new OleDbDataAdapter(stbQuery.ToString(), con);
                    DataSet dsXLS = new DataSet();
                    adp.Fill(dsXLS);
                    DataView dvEmp = new DataView(dsXLS.Tables[0]);
                    trnxlistDataview.DataSource = dvEmp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
