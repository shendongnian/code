      try
                {
                    //string turno = "1";
                    //fillnames(turno);
                    OleDbConnection conn = new OleDbConnection();
                    conn.ConnectionString = @"Provider= Microsoft.ACE.OLEDB.12.0; Data Source=path.accdb;";
                    DataSet ds = new DataSet();
                  
                    OleDbDataAdapter da = new OleDbDataAdapter();
                   DataTableCollection tables = ds.Tables;
                    da = new OleDbDataAdapter("SELECT [Materialista] FROM [OPS] WHERE [Turno] = '" + "1" + "'", conn);
                    da.Fill(ds, "Ops");
                    AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        col.Add(ds.Tables[0].Rows[i]["Materialista"].ToString());
                    }
                    cmb_operador.DataSource = col;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
