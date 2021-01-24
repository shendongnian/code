    public class CustomTextBox : TextBox
    {
        private ContentPresenter _PlaceholderTextContentPresenter;
        public SolidColorBrush PlaceholderForeground
        {
            get { return (SolidColorBrush)GetValue(PlaceholderForegroundProperty); }
            set { SetValue(PlaceholderForegroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderForegroundProperty =
            DependencyProperty.Register("PlaceholderForeground", typeof(SolidColorBrush), typeof(CustomTextBox), new PropertyMetadata(null, PropertyChangedCallback));
        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((d as CustomTextBox)._PlaceholderTextContentPresenter !=null)
            {
                (d as CustomTextBox)._PlaceholderTextContentPresenter.Foreground = e.NewValue as SolidColorBrush;
            }
        }
        protected override void OnApplyTemplate()
        {
            _PlaceholderTextContentPresenter = GetTemplateChild("PlaceholderTextContentPresenter") as ContentPresenter;
        }
        public CustomTextBox()
        {
            DefaultStyleKey = typeof(CustomTextBox);
            
        }
    }
