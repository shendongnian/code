    public class Program
    {
        static void Main(string[] args)
        {
            var config = new JobHostConfiguration();
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            var host = new JobHost();
            host.CallAsync(typeof(Program).GetMethod("runWebJob"));
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
        [NoAutomaticTriggerAttribute]
        public static async Task runWebJob()
        {
            await Task.Delay(1000); //just for test
            Console.WriteLine("RUNNING METHOD");
        }
