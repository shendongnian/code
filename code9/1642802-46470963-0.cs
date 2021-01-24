        //Import Button
        private void button5_Click(object sender, EventArgs e)
        {
            string createColumns = "";
            string columns = "";
            string rows = "";
            var grid = (DataTable)dataGridView3.DataSource;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (i == grid.Columns.Count - 1)
                {
                    createColumns += "[" + grid.Columns[i].ToString() + "] varchar(200) NULL";
                    columns += "[" + grid.Columns[i].ToString() + "]";
                }
                else
                {
                    columns += "[" + grid.Columns[i].ToString() + "],";
                    createColumns += "[" + grid.Columns[i].ToString() + "] varchar(200) NULL,";
                }
            }
            string createTable = string.Format("Create table [{0}] ({1})", textBox1.Text, createColumns);
            rows = string.Format("Insert Into[{0}]({1})", textBox1.Text, columns);
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string row = "";
                for (int c = 0; c < grid.Columns.Count; c++)
                {
                    if (c == grid.Columns.Count - 1)
                        row += "'" + grid.Rows[i][c].ToString() + "'";
                    else
                        row += "'" + grid.Rows[i][c].ToString() + "', ";
                }
                if (i == grid.Rows.Count - 1)
                    rows += string.Format(" ({0});", row);
                else
                {
                    if (i == 0)
                    {
                        rows += " Values";
                    }
                    rows += string.Format(" ({0}),", row);
                }
            }
            string s = "Integrated Security = SSPI;Persist Security Info = False;Data Source = " +
                ServerName.Text + "; Initial Catalog = " +
                Databases.Text;
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand();
        
            cmd.CommandText = createTable;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            SqlCommand cmd2 = new SqlCommand(rows, conn);
            cmd2.CommandType = CommandType.Text;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            Application.Exit();
        }
