    public partial class App : Application, IApplication
    {
        public MyDatabaseEntities Context { get; set; }
    
        // App.xaml.cs Constructor
        public App()
        {
            Context = new MyDatabaseEntities();
        }
    }
