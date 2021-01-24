    private static async Task Try(Func<Task<Object>> methodToRun)
    {
            try
            {
                object ocrResult = await methodToRun();
            }
            catch (Exception e)
            {
            }
    }
    private static Task<object> Blabla(int v)
    {
            throw new NotImplementedException();
    }
    private static Task<object> Blabla()
    {
         throw new NotImplementedException();
    }
