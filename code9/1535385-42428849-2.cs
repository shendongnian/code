    double[] sequence = ...
    object lockObject = new object();
    double sum = 0.0d;
      
    Parallel.ForEach(
        // The values to be aggregated 
        sequence,
        // The local initial partial result
        () => 0.0d,
        // The loop body
        (x, loopState, partialResult) =>
        {
            return Normalize(x) + partialResult;
        },
        // The final step of each local context            
        (localPartialSum) =>
        {
            // Enforce serial access to single, shared result
            lock (lockObject)
            {
                sum += localPartialSum;
            }
        }
    );
    return sum;
