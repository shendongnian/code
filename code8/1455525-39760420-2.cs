    using ScreenTest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace Screentest
    {
        class Program
        {
            static DirectoryInfo di;
            static void Main(string[] args)
            {
    
                args = new string[] { "y" };
    
                if (args[0] == "y")
                {
                    
                    PrintScreen ps = new PrintScreen();
                    ps.CaptureScreen();
    
                }
    
    
            }
        }
    }
