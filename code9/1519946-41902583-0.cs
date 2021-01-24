    var numbers = new List<avl_range>();
    Func<NpgsqlConnection> localInit => () => 
    {
        var conn = new NpgsqlConnection(strConnection);
        conn.Open();
    };
    Action<NpgsqlConnection> localFinally = (conn) => conn.Dispose();
    Func<avl_range, ParallelLoopState, NpgsqlConnection, NpgsqlConnection> forEachLoop = (number, loopState, conn) => //Begin definition of forLoop
    {
         // only the console write line works ok
        Console.WriteLine(number.start + " - " + number.end);
        using (var cmd = new NpgsqlCommand())
        {
            cmd.Connection = conn;                            
            cmd.CommandText = String.Format( "SELECT * FROM avl_db.process_near_link({0}, {1});"
                                             , number.start
                                             , number.end);
            // here cause the error.
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
        }
        return conn;
    };
    Parallel.ForEach(numbers, localInit, forEachLoop, localFinally);
    
