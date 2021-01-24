    public void CreateFile(string path)
    {
        Task<byte[]>[] tasks = new [] { CreateHeaderAsync(), CombineFilesAsync() };
        var resultSet = Task.WhenAll(tasks); // create an aggregate task
        try 
        {
            resultSet.Wait(); // await the results
        }
        catch (AggregateException)
        {
            // handle exceptions in the tasks here
        }
        if (resultSet.Status == TaskStatus.RanToCompletion) 
        {
             // get your results
             byte[] header = resultSet.Result[0]; 
             byte[] files = resultSet.Result[1];
             byte[] combined = new byte[header.Length + files.Length];
             Buffer.BlockCopy(header, 0, combined, 0, header.Length);
             Buffer.BlockCopy(files, 0, combined, header.Length, files.Length);
             Task.Factory.StartNew(() => File.WriteAllBytes(path, combined));
        } 
    }
