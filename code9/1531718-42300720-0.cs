            private void Form1_Load(object sender, EventArgs e)
            {
                string sql = "your sql here";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                chart1.DataBindTable(dt.DefaultView, "yourXFieldColumnName");
            }
