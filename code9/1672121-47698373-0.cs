    using (SqlCommand cmd = new SqlCommand("select Background from Employee where EmployeeName = @Name", con))
            {
                cmd.Parameters.AddWithValue("@Name", txt_name.Text);
                con.Open();
                var dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr); // fill DataTable from reader
                }
                if (dt.Rows.Count > 0 && dt.Rows[0]["Background"] != DBNull.Value)
                {
                    using (MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["Background"]))
                    {
                        this.BackgroundImage = new Bitmap(ms);
                    }
                    // do another stuff
                }
                else
                {
                    // do another stuff
                }
            }con.Close();
