    using (SqlConnection conn = new SqlConnection("Your Connectionstring"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Your select Query", conn);
                  
                    SqlDataReader dr = cmd.ExecuteReader();
 
                    IList<string> listName = new List<string>();
                    while (dr.Read())
                    {
                        listName.Add(dr[0].ToString());
                    }
                    listName = listName.Distinct().ToList();
                    ComboBox1.DataSource = listName;
                }</string></string>
