    public async Task ProcessFile()
    {
        const int parallelism = 5;
    
        using (var readStream = File.OpenRead(@"c:\myinputfile"))
        {
            // put HERE your logic for skipping to a specific line
            // e.g. readStream.Seek(lastPosition); 
    
            using (var reader = new StreamReader(readStream))
            {
                while (!reader.EndOfStream)
                {
                    var tasks = new List<Task<string>>();
    
                    for (var i = 0; i < parallelism; i++)
                    {   
                        var line = await reader.ReadLineAsync();
    
                        tasks.Add(DoWorkAsync(line));
                        if (reader.EndOfStream)
                            break;
                    }
    
                    var results = await Task.WhenAll(tasks);
    
                    using (var writeStream = File.Open(@"d:\myresultfile", FileMode.Append))
                    using (var writer = new StreamWriter(writeStream))
                    {
                        foreach (var line in results)
                            await writer.WriteLineAsync(line);
                    }
                }
            }
        }
    }
    
    public async Task<string> DoWorkAsync(string line)
    {
        await Task.Delay(new Random().Next(1000, 5000));
        // do some work and return line with last parameter = true
        return line.Replace("false", "true"); // e.g.
    }
