    using(var context = new DbContext()) {
        // Get the task
        Task task = (Task)typeof(MyContextExtensions).GetMethod(methodName).Invoke(null, context);
        // Make sure it runs to completion
        await task.ConfigureAwait(false);
        // Harvest the result
        return (object)((dynamic)task).Result;
    }
