    public void CopyFromDB()
    {
            con = new SqlConnection();
            con.ConnectionString = CnString;
            con.Open(); //start     
            SqlCommand cmd = new SqlCommand("SELECT fData FROM [mytbl3] WHERE Id=1", con);
            using (SqlDataReader d = cmd.ExecuteReader())
            {
                if (d.Read())
                {
                    string base64;
                    base64 = reader.GetString(d.GetOrdinal("fData"));
                    byte[] base64byte = Convert.FromBase64String(base64);
                
                    SaveFileDialog ofd = new SaveFileDialog(); ofd.Filter = "exe file|*.exe";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(ofd.FileName, base64byte);
                        System.Threading.Thread.Sleep(3000);
                    }
                }
               
                d.Close();
                //end
                con.Close();
            }
    }
