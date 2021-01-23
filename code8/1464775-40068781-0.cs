    public void autoFill(TextBox abc, TextBox prc) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM pProduct",cnn.con);
                SqlDataReader rd;      
    
                try
                {
    
                    cnn.con.Open();
                    rd = cmd.ExecuteReader();
                    while (rd.Read()) {
                        abc.AutoCompleteCustomSource.Add(rd["Descreption"].ToString());
                        prc.AutoCompleteCustomSource.Add(rd["Price"].ToString());
                    }
                    rd.Close();                
                    cnn.con.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
