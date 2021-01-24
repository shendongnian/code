    public class Program
    {
        public static void Main(string[] args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c time"
            };
            Console.WriteLine("Starting child process...");
            using (var process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }
        }
    }
