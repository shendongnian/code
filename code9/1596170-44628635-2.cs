        int count;
        int processed;
        int progress;
        var collection = Enumerable.Range(1, 111).ToList();
        var chunks = collection.Partition(20).ToList();
        Console.WriteLine("Process chunks (Progress from chunk.Count)");
        count = collection.Count;
        processed = 0;
        foreach (var item in chunks)
        {
            // do some actions with the chunk
            processed += item.Count();
            progress = processed * 100 / count;
            Console.WriteLine(progress);
        }
