      public void load_grid()
            {
                dt.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter();
                try
                {
                    using (con)
                    {
                        string sql = "SELECT * FROM profile";
                        con.Open();
                        da1.SelectCommand = new SqlCommand(sql, con);
                        da1.Fill(dt);
                        //           con.Close();
                    }
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
