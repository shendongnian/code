    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Diagnostics;
    
    namespace TeraTermConnect
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Declare process for .ttl
                Process process = new Process();
                ProcessStartInfo start = new ProcessStartInfo();
    
                //variables
                string ttlpath = @"C:\Program Files (x86)\teraterm\" + @"TTPMACRO";
                string ttl = "new.ttl";
                string ttpHidden = @"/V ";
                ProcessStartInfo start = new ProcessStartInfo();
    
                //start the .ttl file
                start.FileName = ttlpath;
                start.Arguments = ttpHidden + ttl;
                start.UseShellExecute = false;            
    
                process.StartInfo = start;
    
                try
                {
                    Process.Start(start);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                Console.WriteLine("The process is over");
                Console.WriteLine();
                Console.WriteLine("Check the text file...");
                Console.WriteLine();
                Console.WriteLine("Hit enter to exit...");
                Console.ReadKey();
            }
        }
    }
