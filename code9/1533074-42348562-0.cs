     string name;
     SqlCommand command = new SqlCommand("select membername from table1 ", con);
     SqlDataReader read = command.ExecuteReader();
     
    using (StreamWriter sw = new StreamWriter(@"C:\fiscal.txt"))
     { 
     while (read.Read())
     {
     name = (read["membername"].ToString());
     sw.WriteLine("{0,-0}", name.ToString());
     }
     read.Close();
     sw.Close(); 
    }
