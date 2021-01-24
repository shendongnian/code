    class Wow64Mgr
    {
        [STAThread]
        static void Main(string[] args)
        { 
            try
            {
            if(Wow64Interop.EnableWow64FSRedirection(false))
                Console.WriteLine("WOW64 File System Redirection Disabled");
            else
                Console.WriteLine("Failure Disabling WOW64 File System Redirection");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Failure Setting WOW64 File System Redirection.");
                Console.WriteLine(exc.Message);
            }
        }
    }
    public class Wow64Interop
    {
        [DllImport("Kernel32.Dll", EntryPoint="Wow64EnableWow64FsRedirection")]
        public static extern bool EnableWow64FSRedirection(bool enable);
    }
