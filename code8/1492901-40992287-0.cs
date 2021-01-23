    using (var conn = new SqlConnection("Data Source=FATIMAH;Initial Catalog=Bank database;Integrated Security=True"))
                {
                    conn.Open();
                    var sql = "delete FROM Account where number ='" + DropDownList3.SelectedValue + "'";
                    using (var comm = new SqlCommand(sql, conn))
                    {
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
