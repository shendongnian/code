    private void Autocomplete1()
        {
                try
                {
        
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
        
                    SqlCommand cmd = new SqlCommand("SELECT k1 FROM ork ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "k1");
        
                    AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                    int i = 0;
        
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        col.Add(ds.Tables[0].Rows[i]["k1"].ToString());
                    }
        
                    textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox7.AutoCompleteCustomSource = col;
                    textBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
        
                    con.Close();
                }
             catch (Exception ex)
             {
              MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }
