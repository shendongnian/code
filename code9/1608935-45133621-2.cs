    public partial class MainPage : ContentPage
    {
        MyViewModel vm;
    
        public MainPage()
        {
            InitializeComponent();
    
            vm = new MyViewModel();
            BindingContext = vm;
    
            var faveLabel = new Label { FontSize = 24, FontFamily = "FontAwesome", Text = "Tap Here !" };
    
            var trigger1 = new DataTrigger(typeof(Label));
            trigger1.Binding = new Binding("Favorite", BindingMode.TwoWay);
            trigger1.Value = true;
            trigger1.Setters.Add(new Setter { Property = Label.TextColorProperty, Value = Color.Red });
    
            var trigger2 = new DataTrigger(typeof(Label));
            trigger2.Binding = new Binding("Favorite", BindingMode.TwoWay);
            trigger2.Value = false;
            trigger2.Setters.Add(new Setter { Property = Label.TextColorProperty, Value = Color.Gray });
    
            faveLabel.Triggers.Add(trigger1);
            faveLabel.Triggers.Add(trigger2);
    
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
            vm.Favorite = !vm.Favorite;
        }
    }
