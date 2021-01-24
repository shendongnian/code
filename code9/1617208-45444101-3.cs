    public static async Task<object> Run(DurableOrchestrationContext ctx)
    {
        try
        {
            var result = await ctx.CallActivityAsync<object>("FunctionA");
            var y = await ctx.CallActivityAsync<object>("FunctionB", result);
            return y;
        }
        catch (Exception e)
        {
            // error handling/compensation goes here
            await ctx.CallActivityAsync<object>("FunctionC", e);
            return null;
        }
    }
