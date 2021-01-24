    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            if (myEntry.IsFocused)
            {
                myEntry.Unfocus();
            }
            return base.OnBackButtonPressed();
        }
    }
