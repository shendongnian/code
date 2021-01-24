    public partial class MainPage : ContentPage
    {
        Label faveLabel;
        bool favorite = false;
        public MainPage()
        {
            InitializeComponent();
    
            faveLabel = new Label { FontSize = 24, FontFamily = "FontAwesome", Text = "Tap Here !" };
    
            var sl = new StackLayout {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
    
            var tgr = new TapGestureRecognizer();
            tgr.NumberOfTapsRequired = 1;
            tgr.Tapped += tapFavorites;
            sl.GestureRecognizers.Add(tgr);
    
            sl.Children.Add(faveLabel);
    
            Content = sl;
        }
    
        public void tapFavorites(object sender, EventArgs e)
        {
            favorite = ! favorite;
            faveLabel.TextColor = favorite ? Color.Red : Color.Gray;
        }
    }
