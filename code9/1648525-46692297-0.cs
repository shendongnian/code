    public class MyTextBox : TextBox
    {
        static MyTextBox()
        {
            TextProperty.OverrideMetadata(typeof(MyTextBox), new FrameworkPropertyMetadata("", IsDirtyUpdateCallback));
        }
        private static void IsDirtyUpdateCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyTextBox tb && e.NewValue != e.OldValue && e.Property == TextProperty)
            {
                tb.IsDirty = (string)e.OldValue != (string)e.NewValue;
            }
        }
        public bool IsDirty
        {
            get { return (bool)GetValue(IsDirtyProperty); }
            set { SetValue(IsDirtyProperty, value); }
        }
        
        public static readonly DependencyProperty IsDirtyProperty =
            DependencyProperty.Register("IsDirty", typeof(bool), typeof(MyTextBox), new PropertyMetadata(true));
    }
