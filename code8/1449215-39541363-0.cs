    DataTable dt;
            private void Form1_Load(object sender, EventArgs e)
            {
                SqlConnection conn = new SqlConnection("Server=serverName;Database=db;Trusted_Connection=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TestTable", conn);
                dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
