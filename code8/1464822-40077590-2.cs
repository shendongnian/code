    public partial class MainPage : ContentPage
    {
        public Action<object> MainPageCallbackAction { get; set; }
        public MainPage()
        {
            base.BindingContext = this;
            MainPageCallbackAction = MainPageCallbackMethod;
            InitializeComponent();
        }
        private void MainPageCallbackMethod(object param)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Debug.WriteLine("Welcome to the Callback :)");
                Debug.WriteLine("Emixam23 - Example");
            });
        }
    }
