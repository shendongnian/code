    using (var input = new StreamReader(File.OpenRead(@"c:\path\to\my\file.txt")))
    {
        Parallel.ForEach(
            input.ReadLines().TakeChunks(100),
            new ParallelOptions() { MaxDegreeOfParallelism = 8 /* better be number of CPU cores */ },
            batchOfLines => {
                DoMyProcessing(batchOfLines);
            });
    }
