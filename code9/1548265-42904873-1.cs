    /// <summary>
    /// Asynchronously processes each record of the given reader using the given handler
    /// </summary>
    static async Task ProcessResultsAsync(this SqlDataReader reader, Action<object[]> fieldsHandler)
    {
        // Set up async functions for the reader
        var shouldLoopAsync = (Func<Task<bool>>)reader.ReadAsync;
        var getAsync = new Func<SqlDataReader, Func<Task<object[]>>>(_reader =>
        {
            var fieldCount = -1;
            return () => Task.Run(() =>
            {
                Interlocked.CompareExchange(ref fieldCount, _reader.FieldCount, -1);
                var fields = new object[fieldCount];
                reader.GetValues(fields);
                return fields;
            });
        })(reader);
        // Turn the async functions into an IObservable
        var observable = ToObservable(shouldLoopAsync, getAsync);
        // Process the fields as they become available
        var finished = new ManualResetEventSlim(); // This will be our signal for when the observable completes
        using (observable.Subscribe(
            onNext: fieldsHandler, // Invoke the handler for each set of fields
            onCompleted: finished.Set // Set the gate when the observable completes
        )) // Don't forget best practice of disposing IDisposables
            // Asynchronously wait for the gate to be set
            await Task.Run((Action)finished.Wait);
    }
