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
                    
                 di = new DirectoryInfo("C:\\ss");
                 if (!di.Exists){ di.Create(); }                    
               
                PrintScreen ps = new PrintScreen();
                ps.CaptureScreenToFile(di + "\\screen.png",  System.Drawing.Imaging.ImageFormat.Png);
    
                }
    
    
            }
        }
    }
