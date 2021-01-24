    var source = Observable.Create<string>(async (observer, cancellation) =>
    {
        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                // Read a line
                string line = await reader.ReadLineAsync();
    
                // Push the line to the sequence
                observer.OnNext(line);
    
                // Cancellation is requested when the subscription is disposed.
                if (cancellation.IsCancellationRequested)
                {
                    return;
                }
            }
        }
    });
