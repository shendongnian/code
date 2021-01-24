    public async Task<DataTable> loadCombo(string sqlCommand, string value)
            {
                SqlConnection myConn;
                SqlCommand myCmd = default(SqlCommand);
                SqlDataReader oResult;
                DataTable dt = new DataTable();
    
                await Task.Run(() =>
                {
    
                    using (myConn = new SqlConnection("Data Source=" + frmMain.sqlServer + ";" + "Initial Catalog=" + frmMain.sqlData + ";User Id=" + frmMain.sqlUser + ";Password=" + frmMain.sqlPwd + ";"))
                    {
                        try
                        {
                            myConn.Open();
    
                            if (myConn.State == ConnectionState.Open)
                            {
                                myCmd = new SqlCommand((sqlCommand), myConn);
                                oResult = myCmd.ExecuteReader();
                                dt.Load(oResult);
                                myConn.Close();
                            }
                            else
                            {
    
                            }
                        }
                        catch (Exception err)
                        {
                            using (StreamWriter w = File.AppendText("ErrorLog.log"))
                            {
                                frmMain.Log("sqlScripts.loadCombo: " + err.Message, w);
                            }
                        }//End Try
                    }//End using
                });
                return dt;
            }
