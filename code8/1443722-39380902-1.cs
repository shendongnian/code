    public partial class MyCodeGeneratedClass
    {
        public async Task MyCodeGeneratedMethod()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine(await client.GetStringAsync("http://msdn.microsoft.com"));
            MyCustomCode();
        }
    
        partial void MyCustomCode();
    }
    
    partial class MyCodeGeneratedClass
    {
        async partial void MyCustomCode()
        {
            try
            {
                await MyCustomCodeAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
        protected async Task MyCustomCodeAsync()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine(await client.GetStringAsync("http://msdn.microsoft.com"));
    
            throw new Exception("Boom");
        }
    }
