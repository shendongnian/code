    public class TextSeparator : Control
    {
        public static DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header",
            typeof(string), typeof(TextSeparator));
    
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
    }
