    class MyUiControl : Control
    {
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(MyUiControl), new PropertyMetadata(null));
        public IEnumerable ItemsCombo
        {
            get { return (IEnumerable)GetValue(ItemsComboProperty); }
            set { SetValue(ItemsComboProperty, value); }
        }
        public static readonly DependencyProperty ItemsComboProperty =
            DependencyProperty.Register("ItemsCombo", typeof(IEnumerable), typeof(MyUiControl), new PropertyMetadata(null));
        public object Value
        {
            get { return (IEnumerable)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(MyUiControl), new PropertyMetadata(null));
    }
