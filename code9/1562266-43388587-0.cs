    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using WpfApplication1;
    using System.Windows.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                var thread = new Thread(Foo);
                thread.ApartmentState = ApartmentState.STA;
                thread.Start();
    
                Console.ReadKey();
            }
    
            private static void Foo()
            {
                var mainView = new MainWindow();
                mainView.Show();
    
                Dispatcher.Run();
            }
        }
    }
