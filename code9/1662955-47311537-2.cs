    public async static void Main(string[] args) {
        var sourceBlock = new BufferBlock<int>();
        var processBlock1 = new ActionBlock<int>(i => Console.WriteLine($"Block1 {i}"));
        var processBlock2 = new ActionBlock<int>(i => Console.WriteLine($"Block2 {i}"));
        sourceBlock.LinkTo(processBlock1);
        sourceBlock.LinkTo(processBlock2);
        var sourceBlockCompletion = sourceBlock.Completion.ContinueWith(tsk => {
            if(!tsk.IsFaulted) {
                processBlock1.Complete();
                processBlock2.Complete();
            } else {
                ((IDataflowBlock)processBlock1).Fault(tsk.Exception);
                ((IDataflowBlock)processBlock2).Fault(tsk.Exception);
            }
        });
        //Send some data...
        sourceBlock.Complete();
        await Task.WhenAll(sourceBlockCompletion, processBlock1.Completion, processBlock2.Completion);
    }
