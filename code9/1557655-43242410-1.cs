    public partial class MyApp : Application
    {
        public MyApp()
        {
            InitializeComponent();
            // Toggle appTheme.MergedWith based on Idiom 
            appTheme.MergedWith = Device.Idiom == TargetIdiom.Phone ? typeof(PhoneTheme) : typeof(TabletTheme);
        }
    }
