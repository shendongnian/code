        string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        private void button13_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT [Panel Progress].*
                                    FROM [Panel Progress]", con);
                fill_grid();
            }
            catch (Exception error)
            {
                label6.Text = error.Message;
            }
        }
