    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //This will initialize your activity inidicator and set busy to false
            this.activityMonitor.BindingContext = this;
            this.IsBusy = false;
        }
    ...
    }
