    var result = processMe
    .AsParallel()
    .Aggregate
    (
        // seed factory. Each partition will call this to get its own seed
        () => new ConcurrentStack<ProcessResult>(),
        // process element and update accumulator
        (agg, input) =>
        {                                           
            var res = Process(input);
            agg.Push(res);
            return agg;
        },
        // combine accumulators from different partitions
        (agg1, agg2) => {
            agg1.PushRange(agg2.ToArray());
            return agg1;
        },
        // reduce
        agg =>
        {
            ProcessResult res;
            agg.TryPop(out res);
            return res;
        }
    );
