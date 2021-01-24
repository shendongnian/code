    try {
        ThrowSeveralExceptionsAsync(5).Wait();
    }
    catch (AggregateException ex) {
        // flatten, unwrapping all inner aggregate exceptions
        ex.Flatten().Handle(innerEx => {
            Console.WriteLine($"\"{innerEx.Message}\" was thrown");
            return true;
        });
    }
