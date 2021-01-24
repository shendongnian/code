    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    string MyCommand = "-Command &{ if (!(Test-Path 'c:\\test')) {md 'c:\\test'; get-process | Out-File c:\\test\\MyFile.txt}}";
    
    ProcessStartInfo MyProcInfo = new ProcessStartInfo();
    MyProcInfo.FileName = "powershell.exe";
    MyProcInfo.Arguments = MyCommand;
    
    Process MyProcess = new Process();
    MyProcess.StartInfo = MyProcInfo;
    MyProcess.Start();
    MyProcess.WaitForExit();
    
    try
    {
        var lines = File.ReadLines(@"c:\test\MyFile.txt");
     foreach (var ln in lines) {
         Console.WriteLine(ln);
         Console.ReadKey();
    
     }
    } 
    catch (Exception Ex)
    {
      Console.WriteLine(Ex.ToString());
      Console.ReadKey();
    }
            }
