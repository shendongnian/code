    public async Task SomeAsyncMethod()
    {
         while(true)
        {
            await WriteAsync(stream);
            await ReadAsync(stream);
        }
    }
    private static async Task ReadAsync(Stream stream)
    {
        using (Stream console = Console.OpenStandardOutput())
         {
           await CopyStream(stream, console);
         }
    }
    private static async Task WriteAsync(Stream stream)
    {
         using (Stream console = Console.OpenStandardInput())
         {
             await CopyStream(console, stream);
         }
    }
