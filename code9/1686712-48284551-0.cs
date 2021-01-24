    for (int r = 0; r < dataGridView1.Rows.Count; r++)
                {
                    for (int c = 1; c < dataGridView1.Columns.Count; c++)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(constring);
                            SqlCommand query = new SqlCommand("INSERT into RosterTest (EmployeeID, Date, ShiftID) Values (@EmployeeID,@Date,@ShiftID)", con);
                            query.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = dataGridView1.Columns[c].HeaderText;
                            query.Parameters.Add("@Date", SqlDbType.Date).Value = dataGridView1.Rows[r].Cells[0].Value;
                            query.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = dataGridView1.Rows[r].Cells[c].Value;
                            con.Open();
                            query.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
    
                }
