    public static async Task<object> Run(DurableOrchestrationContext ctx)
    {
        try
        {
            var result = await ctx.CallFunctionAsync<object>("FunctionA");
            var y = await ctx.CallFunctionAsync<object>("FunctionB", result);
            return y;
        }
        catch (Exception e)
        {
            // error handling/compensation goes here
            await ctx.CallFunctionAsync<object>("FunctionC", e);
            return null;
        }
    }
