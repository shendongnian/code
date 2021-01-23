    private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("test1");
                dt.Columns.Add("test2");
                dt.Columns.Add("test3");
                string[] row = new string[] { "1", "Product 1", "1000" };
                dt.Rows.Add(row);
                row = new string[] { "2", "Product 2", "2000" };
                dt.Rows.Add(row);
                row = new string[] { "3", "Product 3", "3000" };
                dt.Rows.Add(row);
                row = new string[] { "4", "Product 4", "4000" };
                dt.Rows.Add(row);
                dataGridView1.DataSource = dt;
            }
