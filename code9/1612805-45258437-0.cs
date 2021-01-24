    Tuple<double, string> result = Tuple.Create(double.MaxValue, "");
    
    object syncObject = new object(); 
    Parallel.ForEach(collection, () => Tuple.Create(double.MaxValue, ""),
        (item, loopState, localState) =>
        {
            double value = PerformComputation(item.Item1.Value);
    
            if (value < localState.Item1)
            {
                localState = Tuple.Create(value, item.Item1.Key);
            }
        
            return localState;
        },
        localState =>
        {
            lock(syncObj)
            {
                if (localState.Item1 < result.Item1)
                {
                    result = localState;
                }
            }
        }
    );
