    public class Program
    {
        static Process csProcess;
        static ProcessModuleCollection modules;
        static void Main(string[] args)
        {
            csProcess = Process.GetProcessesByName("notepad").FirstOrDefault();
            if (csProcess == null) { return; } // notepad isn't running
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
