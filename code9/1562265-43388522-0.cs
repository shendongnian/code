    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var thread = new Thread(Foo);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Console.ReadKey();
        }
        private static void Foo()
        {
            var markerService = new MarkerService();
            var viewModel = new MainViewModel();
            markerService.Register(viewModel);
            var mainView = new MainWindow { DataContext = viewModel };
            System.Windows.Application app = new System.Windows.Application();
            app.Run(mainView);
        }
    }
