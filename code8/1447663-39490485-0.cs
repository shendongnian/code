    public class TextBoxBehaviors
    {
        public static bool GetEnforceFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnforceFocusProperty);
        }
        public static void SetEnforceFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(EnforceFocusProperty, value);
        }
        // Using a DependencyProperty as the backing store for EnforceFocus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnforceFocusProperty =
            DependencyProperty.RegisterAttached("EnforceFocus", typeof(bool), typeof(TextBoxBehaviors), new PropertyMetadata(false,
                 (o, e) =>
                 {
                     bool newValue = (bool)e.NewValue;
                     if (!newValue) return;
                     TextBox tb = o as TextBox;
                     if (tb == null)
                     {
                         MessageBox.Show("Target object should be typeof TextBox only. Execution has been seased", "TextBoxBehaviors warning",
                           MessageBoxButton.OK, MessageBoxImage.Warning);
                     }
                     tb.TextChanged += OnTextChanged;
                 }));
        private static void OnTextChanged(object o, TextChangedEventArgs e)
        {
            TextBox tb = o as TextBox;
            tb.Focus();
           /* You have to place your caret at the end of your text manually, because each focus repalce your caret at the beging of text.*/
            tb.CaretIndex = tb.Text.Length;
        }
    }
