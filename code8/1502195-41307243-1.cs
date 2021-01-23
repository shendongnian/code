    class Program {
        static void Main(string[] args) {            
            var ctx = new QueueSynchronizationContext();            
            ctx.Send((state) =>
            {
                // first, execute code on this context
                // so imagine you are in ASP.NET request thread,
                // or in WPF UI thread now                
                SynchronizationContext.SetSynchronizationContext(ctx);                
                Deadlock(new Uri("http://google.com"));                
                Console.ReadKey();
            }, null);
        }
        public static string Deadlock(Uri uri) {
            // we are on "main" thread, doing blocking operation
            return DeadlockingGet(uri).Result;
        }
        public static async Task<string> DeadlockingGet(Uri uri)
        {
            using (var http = new HttpClient())
            {
                // await in async method
                var response = await http.GetAsync(uri);
                // this is continuation of async method
                // it will be posted to our context (you can see in debugger), and will deadlock
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
