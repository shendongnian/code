    string cmdText = "INSERT INTO PERSON(Name, LastName) VALUES(?,?)";
    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"dbs.accdb\"";
    using(OleDbConnection con = new OleDbConnection(ConnectionString))
    {
        con.Open();
        Console.Write("A number of persons to add: ");
        int number= Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            using(OleDbCommand addCmd = new OleDbCommand(cmdText, con))
            {
               Console.Write("Name:");
               string name= Console.ReadLine();
               addCmd.Parameters.Add(new OleDbParameter("@Name", name));
               Console.Write("Last Name:");
               string lastName= Console.ReadLine();
               addCmd.Parameters.Add(new OleDbParameter("@LastName", lastName));
               addCmd.ExecuteNonQuery();
           }
       }
    }
