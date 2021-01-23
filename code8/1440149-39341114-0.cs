    public class Class1
    {
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(
                nameof(Filter),
                typeof(Filter),
                typeof(Class1),
                new PropertyMetadata(OnPropertyChanged));
    
        public static readonly DependencyProperty FilterStatementProperty =
            DependencyProperty.Register(
                nameof(FilterStatement),
                typeof(string),
                typeof(Class1),
                new PropertyMetadata(OnPropertyChanged));
    
        public Filter Filter
        {
            get { return (Filter)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }
    
        public string FilterStatement
        {
            get { return (string)GetValue(FilterStatementProperty); }
            set { SetValue(FilterStatementProperty, value); }
        }
    
        public Class2 MyClass2Instance { get; set; }
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = (Class1)d;
            if (c.MyClass2Instance?.MyClass3Instance != null)
            {
                if (e.Property == FilterProperty)
                {
                    c.FilterStatement = c.MyClass2Instance.MyClass3Instance.MyFilterToStatementConversionMemberFunction((Filter)e.NewValue);
                }
                else if (e.Property == FilterStatementProperty)
                {
                    c.Filter = c.MyClass2Instance.MyClass3Instance.MyStatementToFilterConversionMemberFunction((string)e.NewValue);
                }
            }
        }
    }
