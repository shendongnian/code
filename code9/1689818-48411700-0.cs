           var simulationResults =
                Enumerable.Range(0, 10000)
                    .AsParallel()
                    .WithCancellation(token ?? CancellationToken.None)
                    .Select(z =>
                    {
                        progressAction?.Invoke();
                        return someMethod();
                    })
                    .TakeWhile(result => !double.IsNaN(result));
