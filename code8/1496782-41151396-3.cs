    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.IO;
    using System;
    using System.Windows.Forms;
    using System.Windows.Input;
    namespace ConsoleApplication10
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                KeyListener.RegisterHotKey(Keys.A);
                KeyListener.HotKeyPressed += new EventHandler<HotKeyEventArgs>(KeyListener_HotKeyPressed);
                while (true)
                {
                    Console.ReadKey(true);
                }
            }
    
            static void KeyListener_HotKeyPressed(object sender, HotKeyEventArgs e)
            {
                switch (e.Key)
                {
                    case Keys.A:
                    {
                        Console.WriteLine("Do stuff");
                        return;
                    }
                    default:
                        return;
                }
            }
        }
    }
