    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.CurrentPageChanged += MainPage_CurrentPageChanged;
            ChangeBarColor();
        }
    
        protected override void OnDisappearing()
        {
            this.CurrentPageChanged -= MainPage_CurrentPageChanged;
            base.OnDisappearing();
        }
    
        private void MainPage_CurrentPageChanged(object sender, EventArgs e)
        {
            ChangeBarColor();
        }
    
        private void ChangeBarColor()
        {
            var currentPage = this.CurrentPage;
            switch (currentPage.Title)
            {
                case "Today":
                    this.BarTextColor = Color.Green;
                    break;
    
                case "Schedule":
                    this.BarTextColor = Color.Orange;
                    break;
            }
        }
    }
