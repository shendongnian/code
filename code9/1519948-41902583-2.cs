    var numbers = GetDataForNumbers();
    List<string> results = new List<string>();
    Func<List<string>> localInit => () => new List<string>();
    Func<avl_range, ParallelLoopState, List<string>, List<string>> forEachLoop = (number, loopState, localList) => //Begin definition of forLoop
    {
        using (var conn = new NpgsqlConnection(strConnection))
        {
            conn.Open();
            //This line is going to slow your program down a lot.
            //Console.WriteLine(number.start + " - " + number.end);
    
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;                            
                cmd.CommandText = String.Format( "SELECT * FROM avl_db.process_near_link({0}, {1});"
                                                 , number.start
                                                 , number.end);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Add a object to the thread local list, we don't need to lock here because we are the only thread with access to it.
                        localList.Add(reader.GetString(0));
                    }
                }
            }
        }
        return localList;
    };
    Action<List<String>> localFinally = localList => 
    {
        //Combine the local list to the main results, we need to lock here as more than one thread could be merging at once.
        lock(results)
        {
            results.AddRange(localList);
        }
    };
    Parallel.ForEach(numbers, localInit, forEachLoop, localFinally);
    //results now contains strings from all the threads here.
