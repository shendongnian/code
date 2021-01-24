    public class Program
    {
        static Process[] csProcess;
        static ProcessModuleCollection modules;
        static void Main(string[] args)
        {
            csProcess = Process.GetProcessesByName("notepad");
            modules = csProcess.Modules;
            foreach (ProcessModule module in modules)
            {
                if (module.ModuleName == "client.dll")
                {
                    // do stuff
                }
            }  
        }
    }
