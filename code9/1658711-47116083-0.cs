    public class TextBoxWithHint : TextBox
    {
        private readonly VisualBrush vb;
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }
        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxWithHint), new UIPropertyMetadata(string.Empty));
        public TextBoxWithHint()
        {
            Label l = new Label { Foreground = new SolidColorBrush(Colors.LightGray) };
            Binding b = new Binding
            {
                Source = this,
                Path = new PropertyPath("Watermark"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(l, ContentControl.ContentProperty, b);
            vb = new VisualBrush(l) { AlignmentX = AlignmentX.Left, AlignmentY = AlignmentY.Center, Stretch = Stretch.None };
            GotKeyboardFocus += TextBoxWithHint_GotKeyboardFocus;
            LostKeyboardFocus += TextBoxWithHint_LostKeyboardFocus;
            Initialized += TextBoxWithHint_Initialized;
        }
        private void TextBoxWithHint_Initialized(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text) && !IsKeyboardFocused) SetBackgroundWatermark();
            else SetBackgroundPlain();
        }
        private void TextBoxWithHint_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Text) && Background.GetType() == typeof(SolidColorBrush)) SetBackgroundWatermark();
        }
        private void TextBoxWithHint_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (Background.GetType() == typeof(VisualBrush)) SetBackgroundPlain();
        }
        private void SetBackgroundWatermark() { Background = vb; }
        private void SetBackgroundPlain() { Background = new SolidColorBrush(Colors.White); }
    }
