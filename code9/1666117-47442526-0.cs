    public async Task TransformManyExample() {
        var data = Enumerable.Range(0, 10).ToList();
        var block1 = new TransformManyBlock<IEnumerable<int>, int>(x => x);
        var block2 = new ActionBlock<int>(x => Console.WriteLine(x.ToString()));
        block1.LinkTo(block2, new DataflowLinkOptions() { PropagateCompletion = true });
        block1.Post(data);
        block1.Complete();
        await block2.Completion;
    }
