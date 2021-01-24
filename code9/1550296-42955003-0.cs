    public sealed partial class CreatureDossier : Page
    {
        private Species Cat;
        public CreatureDossier()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Cat = (Species)e.Parameter;
            DataContext = Cat;
        }
    }
