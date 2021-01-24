    using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
