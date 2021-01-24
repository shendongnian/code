    private void foo(CancellationToken token)
    {
        using(var reader=new StreamReader(somePath)
        {
                string line;
                // Read the line if no cancellation was requested
                while ((line = sr.ReadLine()) != null) 
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine(line);
                }
        }
    }
