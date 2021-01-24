    public class TextBoxBehaviors
    {
        public static readonly DependencyProperty SelectAllOnFocusProperty = DependencyProperty.RegisterAttached("SelectAllOnFocus",  typeof(bool), typeof(TextBoxBehaviors), new PropertyMetadata(false, OnSelectAllOnFocusChanged));
        public static DependencyProperty GetSelectAllOnFocus(TextBox element)
        {
            return (DependencyProperty)element.GetValue(SelectAllOnFocusProperty);
        }
        public static void SetSelectAllOnFocus(TextBox element, bool value)
        {
            element.SetValue(SelectAllOnFocusProperty, value);
        }
        private static void OnSelectAllOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            if (comboBox != null)
            {
                comboBox.Loaded += ComboBox_Loaded;
                return;
            }
            var textBox = d as TextBox;
            if (textBox == null) { return; }
            if ((bool)e.OldValue)
            {
                textBox.PreviewMouseDown -= TextBox_PreviewMouseDown;
                textBox.GotFocus -= TextBox_GotFocus;
            }
            if (!(bool)e.NewValue)
                return;
            textBox.PreviewMouseDown += TextBox_PreviewMouseDown;
            textBox.GotFocus += TextBox_GotFocus;
        }
        private static void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var comboText = comboBox?.Template.FindName("PART_EditableTextBox", comboBox) as TextBox;
            comboText?.SetValue(SelectAllOnFocusProperty, comboBox.GetValue(SelectAllOnFocusProperty));
        }
        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) { return; }
            // We need to dispatch this in case someone is changing the text during the GotFocus
            // event.  In that case, we want to select it all after they're done.
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                                       (Action)(() => TextBox_DoSelectAll(textBox)));
        }
        private static void TextBox_DoSelectAll(TextBox textBox)
        {
            if (!textBox.IsFocused) return;
            textBox.CaretIndex = textBox.Text.Length;
            textBox.SelectAll();
        }
        private static void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) { return; }
            if (textBox.IsFocused)
                return;
            textBox.Focus();
            e.Handled = true;  // Prevent default TextBox behavior from deselecting text on mouse up
        }
}
