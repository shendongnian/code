    public static async Task<int> MyMethodAsync()
    {
        try
        {
            await Task.Run(()=>act1());
            await Task.Run(()=>act2());
            var result=await Task.Run(()=>act3());
            return result;
        }
        catch (Exception exc)
        {
               //Do something
        }
    }
