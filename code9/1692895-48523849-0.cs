        str = @"..........";
        using(con = new SqlConnection(str))
        {
            con.Open();
            Console.WriteLine("Database connected");
            string query = "INSERT INTO[dbo].[Table]([Price], [Buyable]) VALUES('" + Add + "'," + Buyable + ")";
            SqlCommand ins = new SqlCommand(query, con);
            ins.ExecuteNonQuery();
            Console.WriteLine("Stored");
            Console.ReadKey();
        }
