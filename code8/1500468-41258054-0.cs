    private void LoadData()
            {
                using (SqlConnection con = new SqlConnection("Data Source=servername;Initial Catalog=MyDB;Persist Security Info=True;User ID=sa; Password =password123;"))
                {
                    con.Open();
                    AutoCompleteStringCollection citycollection = new AutoCompleteStringCollection();
                    string Qry = "select * from Cities";
                    SqlCommand cmd = new SqlCommand(Qry, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            citycollection.Add(dr["Name"].ToString());
                        }
    
                    }
                    textBox1.AutoCompleteMode = AutoCompleteMode.Append;
                    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox1.AutoCompleteCustomSource = citycollection;
                }
            }
