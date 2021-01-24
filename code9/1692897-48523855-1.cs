    static void Main(string[] args)
    {
        double Add = 0D; //You really should use a **decimal** for anything to do with money!
        int Buyable = 0;
        int count = 10; 
        string str = @"..........";
        string sql = "INSERT INTO[dbo].[Table]([Price], [Buyable]) VALUES(@Add, @Buyable);";    // + Add + "'," + Buyable + ")";
        using (SqlConnection con = new SqlConnection(str))
        using (SqlCommand ins = new SqlCommand(sql))
        {
            cmd.Parameters.Add("@Add", SqlDbType.Float);
            cmd.Parameters.Add("@Buyable", SqlDbType.Int); //guessing at parameter type here
            con.Open();
            Console.WriteLine("Database connected");
            for (int i = 0; i < count; i++)
            {
                Add += 0.00000005D;    
                try
                {
                    cmd.Parameters["@Add"].Value = Add;
                    cmd.Parameters["@Buyable"].Value = Buyable;
                    ins.ExecuteNonQuery();
                    Console.WriteLine("Stored");
                    Console.ReadKey();
                }
                catch (SqlException ex)
                { 
                    //Do *something* with the exception here!
                    Console.WriteLine("Error using the database. The message is:\n{0}", ex.Message);         
                }
            }
        }
    }
