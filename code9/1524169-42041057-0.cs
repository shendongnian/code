    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"dbs.accdb\"";
            OleDbConnection con = new OleDbConnection(ConnectionString);
           
            Console.Write("A number of persons to add: ");
            int number= Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                OleDbCommand addCmd = new OleDbCommand("INSERT INTO PERSONA(Name, LastName) VALUES(?,?)", con);
                con.Open();
                Console.Write("Name:");
                string name= Console.ReadLine();
                addCmd.Parameters.Add(new OleDbParameter("@Name", name));
                Console.Write("Last Name:");
                string lastname= Console.ReadLine();
                addCmd.Parameters.Add(new OleDbParameter("@LastName", lastname));
                Console.WriteLine();
                addCmd.ExecuteNonQuery();
                con.Close();
            }
