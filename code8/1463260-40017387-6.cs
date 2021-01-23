    public static readonly DependencyProperty ItemsBackgroundProperty =
              DependencyProperty.Register("ItemsBackground", typeof(string), typeof(UserControl1),
                  new FrameworkPropertyMetadata());
    
    
            public string ItemsBackground
            {
                get { return (string)GetValue(ItemsBackgroundProperty); }
                set { SetValue(ItemsBackgroundProperty, value); }
            }
