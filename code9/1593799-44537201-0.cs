    string constring = @"Data Source=.\SQL2005;Initial Catalog=gridconnection;";
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("select * from GridExcel", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
