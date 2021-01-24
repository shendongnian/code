    using(var con=new SqlConnection(connString))
    {
        con.Open();
        var command = new SqlCommand("select membername from table1 ", con);
        using(var read = command.ExecuteReader())
        using (StreamWriter sw = new StreamWriter(@"C:\fiscal.txt"))
        {
            while (read.Read())
            {
                var name = read["membername"]);
                sw.WriteLine("{0,-0}", name);
            }
        }
    }
