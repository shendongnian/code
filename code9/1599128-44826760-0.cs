        public string CustomText        
        {
            get { return (string)GetValue(CustomTextProperty); }
            set { SetValue(CustomTextProperty, value); }
        }
        public static readonly DependencyProperty CustomTextProperty = DependencyProperty.Register(
            nameof(CustomText),
            typeof(string),
            typeof(CustomControl),
            new PropertyMetadata(string.Empty, OnPropertyChanged));
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as CustomControl;
            if(instance.CustomText != "") 
                myTextBlock.Text = instance.CustomText;
        }
