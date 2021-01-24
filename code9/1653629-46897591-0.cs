     int Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
      try
            {
                using (SqlConnection conn = new SqlConnection(_csData))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand("updateTable", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add("@vrID", SqlDbType.Int).Value = Id;
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.SelectCommand = comm;
                    DataTable db = new DataTable();
                    da.Fill(db);
                    dataGridView1.DataSource = db;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("An error occurred: '{0}'", ex.Message));
            }
       }
