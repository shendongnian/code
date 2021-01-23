    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void MyView_OnMyEvent(object sender, string e)
        {
            Debug.WriteLine(e);
        }
    }
