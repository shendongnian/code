    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            var command = @"C:\Users\Me\Desktop\TempExtract\MyApp\*.* " + @"\\TestShare\SharedFolder\Applications\ /Y /I";
            var Processo = new Process();
            var Xcopy = new ProcessStartInfo("cmd.exe")
            {
                Arguments = command,
                FileName = "xcopy",
                UseShellExecute = false
            };
            Processo = Process.Start(Xcopy);
            Processo.WaitForExit();
        }
    }
