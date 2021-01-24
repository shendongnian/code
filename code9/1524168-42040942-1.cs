    string cmdText = "INSERT INTO PERSON(Name, LastName) VALUES(?,?)";
    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"dbs.accdb\"";
    using(OleDbConnection con = new OleDbConnection(ConnectionString))
    using(OleDbCommand addCmd = new OleDbCommand(cmdText, con))
    {
        con.Open();
        addCmd.Parameters.Add("@Name", OleDbType.VarWChar);
        addCmd.Parameters.Add("@LastName", OleDbType.VarWChar);
        Console.Write("A number of persons to add: ");
        int number= Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            {
               Console.Write("Name:");
               string name= Console.ReadLine();
               addCmd.Parameters["@Name"].Value = name;
               Console.Write("Last Name:");
               string lastName= Console.ReadLine();
               addCmd.Parameters["@LastName"].Value = lastName;
               addCmd.ExecuteNonQuery();
           }
       }
    }
