    // if you want to read more lines change this to the ammount of lines you want
    const int LINES_KEPT = 2;
    Queue<string> meQueue = new Queue<string>();
    using ( StreamReader reader = new StreamReader(File.OpenRead("C:\\test.log")) )
    {
        string line = string.Empty;
        while ( ( line = reader.ReadLine() ) != null )
        {
            if ( meQueue.Count == LINES_KEPT  )
               meQueue.Dequeue();
    
            meQueue.Enqueue(line);
        }
    }
