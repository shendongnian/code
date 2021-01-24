 		public class Program
                {
                private const int MF_BYCOMMAND = 0x00000000;
                public const int SC_CLOSE = 0xF060;
           
                [DllImport("user32.dll")]
                public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
            
                [DllImport("user32.dll")]
                private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
            
                [DllImport("kernel32.dll", ExactSpelling = true)]
                private static extern IntPtr GetConsoleWindow();
            
                static void Main(string[] args)
                {
                    DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                    Timer t = new Timer(TimerCallback, null, 0, 5000);
        
            //Removed readline and added while loop (infinite)
                while(true)
                {
                }
                    
        
                }
            
                private static void TimerCallback(Object o)
                {
                    Console.WriteLine("SMS Banking Schedule: " + DateTime.Now);
                    DLLSendSMS dllSendSMS = new DLLSendSMS();
                    dllSendSMS.GetMessages(null);
                    GC.Collect();
                }
            
            }
