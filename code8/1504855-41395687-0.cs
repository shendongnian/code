    public static readonly DependencyProperty PopUpLaunched = DependencyProperty.Register(
        "popUpLaunched", typeof(bool), typeof(MainPage), new PropertyMetadata(null));
    
            public bool popUpLaunched
            {
                get { return (bool)GetValue(PopUpLaunched); }
                set { SetValue(PopUpLaunched, value); }
            }
