    public static async Task<object> Run(DurableOrchestrationContext ctx)
    {
        var x = await ctx.CallActivityAsync<object>("YourOtherFunctionName");
        // Rest of Function code
    }
