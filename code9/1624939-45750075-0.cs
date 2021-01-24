    private void button2_Click(object sender, EventArgs e)
            {
                //database connection string and opening area
                string oracleDb = @"connection string";
                OracleConnection conn = new OracleConnection(oracleDb);
                conn.Open();
    
                //declareing paramater and readning parameter input
                OracleParameter param = new OracleParameter();
                param.OracleDbType = OracleDbType.Decimal;
                param.Value = txtlist.Text;
    
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
    
                //sendting the parameter to the tabase query 
                cmd.Parameters.Add(param);
                cmd.CommandText = "SELECT NAME, ADDRESS  FROM FRIENDS WHERE age = :1";
    
                cmd.CommandType = CommandType.Text;
                OracleDataReader dataread = cmd.ExecuteReader();
                dataread.Read();
    
                if (dataread.HasRows)
                {
                    while (dataread.Read())
                    {
                        listBox1.Items.Add(dataread.GetString(1) + " from " + dataread.GetString(2));
                    }
                }
                else
                {
                    listBox1.Text = "Not Found";
                    MessageBox.Show("Data Not found", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Dispose();
            }
