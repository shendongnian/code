    string result3 = Checked_By.ToString().Substring(0, 3);
    
    SqlCommand cmd = new SqlCommand(" SELECT [Kode], [Nama] FROM [Job] WHERE LEFT(Kode, 3) = @result3 ORDER BY Nama", con); //ASC is OK but not required as it is default option
    cmd.Parameters.Add("@result3", SqlDbType.Char, 3).Value = result3;
    
     SqlDataAdapter sda = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
     //con.Open(); //not necessary. SqlDataAdapter.Fill opens connection if it needs
     sda.Fill(dt);
     //con.Close(); //and closed if it wasn't open before .Fill
