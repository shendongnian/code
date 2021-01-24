    public static class Program
    {
        public static void Main(String[] args)
        {
            Boolean backend = args.Contains("-b");
            // ...
            MyApp app = new MyApp(backend);
            app.Run();
        }
    }
    public partial class MyApp : Application
    {
        public MyApp(Boolean backend)
        {
            InitializeComponent();
            if (backend)
                Cursor = Cursors.None;
        }
    }
