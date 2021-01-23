    public partial class AddSchool : ContentPage
    {
        public delegate void PopupClosedDelegate();
    
        public event PopupClosedDelegate PopupClosed;
    
        public AddSchool()
        {
            InitializeComponent();
        }
        private async void Button_OK_Clicked(object sender, EventArgs e)
        {
            //doing some operations like entry to db etc and close page
            await Navigation.PopModalAsync();
            if (PopupClosed!=null)
            {
                PopupClosed();
            }
        }
        private async void cancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            if (PopupClosed != null)
            {
                PopupClosed();
            }
        }
    }
