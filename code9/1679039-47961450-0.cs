    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Begin");
            Get<string>("key", 1000);
            Console.WriteLine("End");
        }
        
        public static T Get<T>(string key, int? maxMilisecondsForResponse = null)
        {
            var result = default(T);
    
            try
            {
                var task = Task.Run(async () =>
                {
                    await Task.Delay(maxMilisecondsForResponse.Value);
                    throw new Exception("Timer elapsed");
                });
                task.Wait();
            }
            catch (Exception ex)   
            {
                // why the exception is not catched here?
                Console.WriteLine(ex);
            }
    
            return result;
        }
    }
