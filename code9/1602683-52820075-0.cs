    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace ExecuteCommandX
    {
     /// <summary>
    ///  sample by linkanyway@gmail.com
    /// </summary>
    /// <param name="args"></param>
    internal static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "ping",
                Arguments = "-c 3 8.8.8.8",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var proc = new Process
            {
                StartInfo = psi
            };
            proc.Start();
           
            Task.WaitAll(Task.Run(() =>
            {
                while (!proc.StandardOutput.EndOfStream)
                {
                    var line = proc.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
            }), Task.Run(() =>
            {
                while (!proc.StandardError.EndOfStream)
                {
                    var line = proc.StandardError.ReadLine();
                    Console.WriteLine(line);
                }
            }));
            proc.WaitForExit();
            Console.WriteLine(proc.ExitCode);
        }
    }
}
