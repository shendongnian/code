    private void foo(CancellationToken token)
    {
        using(var reader=new StreamReader(somePath)
        {
                string line;
                // Read the line if no cancellation was requested
                while (!token.IsCancellationRequested && (line = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
        }
    }
