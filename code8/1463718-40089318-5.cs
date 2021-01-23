    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            // Define the binding context
            this.BindingContext = this;
            // Set the IsBusy property
            this.IsBusy = false;
            // Login button action
            this.BtnLogin.Clicked += BtnLogin_Clicked;
        }
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
        }
    }
