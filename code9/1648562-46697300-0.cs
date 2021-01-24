    var buffer = new BufferBlock<int>();
    var consumer1 = new ActionBlock<int>(i => Console.WriteLine($"First: {i}"));
    var consumer2 = new ActionBlock<int>(i => Console.WriteLine($"Second: {i}"));
    var consumer3 = new ActionBlock<int>(i => Console.WriteLine($"Third: {i}"));
    var consumer4 = new ActionBlock<int>(i => Console.WriteLine($"Forth: {i}"));
    buffer.LinkTo(consumer1, i => Predicate(0));
    buffer.LinkTo(consumer2, i => Predicate(1));
    buffer.LinkTo(consumer3, i => Predicate(2));
    buffer.LinkTo(consumer4, i => Predicate(3));
    buffer.LinkTo(DataflowBlock.NullTarget<int>());
    for (var i = 0; i < 10; ++i)
    {
        buffer.Post(i);
    }
    buffer.Completion.Wait();
