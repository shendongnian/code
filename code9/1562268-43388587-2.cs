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
                var markerService = new MarkerService();
                var viewModel = new MainViewModel();
                markerService.Register(viewModel);
                var mainView = new MainWindow { DataContext = viewModel };
                mainView.Show();
    
                Dispatcher.Run();
            }
        }
    }
