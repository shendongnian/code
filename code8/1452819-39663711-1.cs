    SqlDataReader Rdr = Cmd.ExecuteReader();
    if (Rdr.HasRows)
    {
       using (StreamWriter writer = new StreamWriter("c:\\Test.txt"))
       {
          string eol = ""; 
          while (Rdr.Read())
          {
              writer.Write("{0}{1}{2}", eol, Rdr["Item1"], Rdr["Item2"]);
              eol = Environment.NewLine;
          }
       }                        
     }
     Rdr.Close(); 
