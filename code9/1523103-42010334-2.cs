    public Task ProcessDataAsync(IEnumerable<SomeInput> input)
    {
        using(var outfile = new File.OpenWrite("outfile.txt"))
        {
            //Create a convert action that uses the number of processors on the machine to create parallel blocks for processing.
            var convertBlock = new TransformBlock<SomeInput, string>(x => CpuIntensiveConversion(x), new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = Enviorment.ProcessorCount});
            //Create a single threaded action that writes out to the textwriter.
            var writeBlock = new ActionBlock<string>(x => outfile.WriteLine(x))
        
            //Link the convert block to the write block.
            convertBlock.LinkTo(writeBlock, new DataflowLinkOptions{PropagateCompletion = true});
            //Add items to the convert block's queue.
            foreach(var item in input)
            {
                  await convertBlock.SendAsync();
            }
            //Tell the convert block we are done adding. This will tell the write block it is done processing once all items are processed.
            convertBlock.Complete();
            //Wait for the write to finish writing out to the file;
            await writeBlock.Completion;
        }
    }
