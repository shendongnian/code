                using (var con = new SqlConnection("your conn string"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
    
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@param0", null));
                    sqlParams.Add(new SqlParameter("@param1", null));
                    sqlParams.Add(new SqlParameter("@param2", null));
                    sqlParams.Add(new SqlParameter("@param3", null));
                    sqlParams.Add(new SqlParameter("@param4", null));
                    sqlParams.Add(new SqlParameter("@param5", null));
                    sqlParams.Add(new SqlParameter("@param6", null));
    
                    cmd.Parameters.AddRange(sqlParams.ToArray());
    
                    for (int i = 0; i < dataPOS.Rows.Count; i++)
                    {
                        cmd.Parameters["@param0"].Value = dataPOS.SelectedRows[0].Cells[0].Value.ToString();
                        cmd.Parameters["@param1"].Value = dataPOS.SelectedRows[0].Cells[1].Value.ToString();
                        cmd.Parameters["@param2"].Value = dataPOS.SelectedRows[0].Cells[2].Value.ToString();
                        cmd.Parameters["@param3"].Value = dataPOS.SelectedRows[0].Cells[3].Value.ToString();
                        cmd.Parameters["@param4"].Value = dataPOS.SelectedRows[0].Cells[4].Value.ToString();
                        cmd.Parameters["@param5"].Value = dataPOS.SelectedRows[0].Cells[5].Value.ToString();
                        cmd.Parameters["@param6"].Value = dataPOS.SelectedRows[0].Cells[6].Value.ToString();
    
                        dataPOS.Rows[i].Selected = true;
                        cmd.CommandText = @"INSERT INTO TRANSACTIONS (TransactionCode,TransactionDate,ItemCode,ItemName,Quantity,Price,Total)
                                            VALUES (@param0, @param1, @param2, @param3, @param4, @param5,@param6 )";
                        cmd.ExecuteNonQuery();
                        dataPOS.Rows[i].Selected = false;
                    }
                    con.Close();
                }
