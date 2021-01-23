    public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string),
                                        typeof(DesignerItem),
                                        new FrameworkPropertyMetadata(false)); // thats the mistake you cant have boolean here
