    public static async Task Loop()
    {
        while(true)
        {
            var workTask = DoWork();
            if(workTask.GetAwaiter().IsCompleted) //This IsCompleted property is the thing that determines if the code will be synchronous.
                await Task.Yield(); //If we where syncronous force a return here via the yield.
            await workTask; //We still await the task here in case where where not complete, also to observe any exceptions.
        }
    }
