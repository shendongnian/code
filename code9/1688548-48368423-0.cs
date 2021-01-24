    // Use a queue to allow the 5 threads to pull the next record
    var workItems = new ConcurrentQueue<Record>();
    
    // Add your 1000 Records to workItems queue
    
    // Start 5 workers to process the Records in the queue
    Parallel.ForEach(Enumerable.Range(0,5), index =>
    {
        // Create a separate file for each thread to work with
        var fileName = string.Format("outputFile_{0}.txt", index);
    
        using (var outputStream = new StreamWriter(fileName))
        {
            // Dequeue Records from the queue until they're all processed
            while (!workItems.IsEmpty)
            {
                Record record;
                if (workItems.TryDequeue(out record))
                {
                    // Process each record and write to the file
                    var result = ProcessRecord(record);
                    outputStream.Write(result);
                }
            }
        }
    })
