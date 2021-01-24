    namespace Watson.Views
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class StartScan : ContentPage
        {
            public StartScan()
            {
                NavigationPage.SetHasBackButton(this, false);
                InitializeComponent();
            }
            protected override bool OnBackButtonPressed()
            {
                // you can put some actions here (for example, an dialog prompt, ...)
                return true;
            }
        }
    }
