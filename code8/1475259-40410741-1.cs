    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using ConsoleHotKey;
    
    namespace ConsoleTester
    {
        class Program
        {
            static bool exitApp = false;
    
            static void Main(string[] args)
            {
                HotKeyManager.RegisterHotKey(Keys.X, KeyModifiers.Control);
                HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
                
                //this loop is only to keep app from exiting...
                while (!exitApp)
    	        {
    	            Console.WriteLine("Press Ctrl+X to exit!");
                    System.Threading.Thread.Sleep(1000);
    
                    //TODO: write you code...
    	        }
            }
    
            static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
            {
                Console.WriteLine("Application will exit!");
                exitApp = true;
            }
        }
    
    
    }
