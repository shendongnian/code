    public partial class LearnPage : ContentPage
    {
        public LearnPage ()
        {
            InitializeComponent();
            BindingContext = new LearnViewModel();
        }
    }
