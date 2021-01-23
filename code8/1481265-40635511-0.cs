     private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LPMSW09000012JD\\SQLEXPRESS;Initial Catalog=Pharmacies;Integrated Security=True");
            string filepath = textBox2.Text; //"C:\\Users\\jdavis\\Desktop\\CRF_105402_New Port Maria Rx.csv";
            StreamReader sr = new StreamReader(filepath);
            string line = sr.ReadLine();
            string[] value = line.Split(',');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value)
            {
                dt.Columns.Add(new DataColumn(dc));
            }
            while (!sr.EndOfStream)
            {
                value = sr.ReadLine().Split(',');
                if (value.Length == dt.Columns.Count)
                {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
            }
            SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
            bc.DestinationTableName = textBox1.Text;
            bc.BatchSize = dt.Rows.Count;
            con.Open();
            bc.WriteToServer(dt);
            bc.Close();
            con.Close();
        }
