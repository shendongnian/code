       public void AddData()
        {
            using (IDbConnection dbconnection = new SQLiteConnection(conn))
            {
                dbconnection.Open();
                using (IDbCommand dbCmd = dbconnection.CreateCommand())
                {
                    string sqlQuery = "INSERT INTO tbl_sample (Name,Age) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')"; ;
                    dbCmd.CommandText = sqlQuery;
                   
                    using (IDataReader reader = dbCmd.ExecuteReader())
                    {
                            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM tbl_Sample", conn);
                            DataSet ds = new System.Data.DataSet();
                            dataadapter.Fill(ds, "Info");
                            dataGridView1.DataSource = ds.Tables[0];
                        
                        dbconnection.Close();
                    }
                }
            }
        }
