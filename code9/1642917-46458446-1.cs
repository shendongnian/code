        public partial class App : Application
        {
            public GetSetJsonData GetSetJsonDataInstance { get; private set; }
            public App()
            {
                InitializeComponent();
                GetSetJsonDataInstance = new GetSetJsonData();
            }
            ...
        }
        // Then you can access to the instance using:
        ((App)Application.Current).GetSetJsonDataInstance
