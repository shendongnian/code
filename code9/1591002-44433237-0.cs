    public class EmptyToNaBehaviour
    {
        public static string GetText(TextBlock textBlock)
        {
            return (string)textBlock.GetValue(IsBroughtIntoViewWhenSelectedProperty);
        }
        public static void SetText(TextBlock textBlock, string value)
        {
            textBlock.SetValue(IsBroughtIntoViewWhenSelectedProperty, value);
        }
        public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
            "Text",
            typeof(string),
            typeof(EmptyToNaBehaviour),
            new UIPropertyMetadata(null, OnTextChanged));
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock txtblock = d as TextBlock;
            if(txtblock != null)
                txtblock.Loaded += Txtblock_Loaded;
        }
        private static void Txtblock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock txtblock = sender as TextBlock;
            string text = GetText(txtblock);
            if (txtblock != null && !string.IsNullOrEmpty(text) && string.IsNullOrEmpty(txtblock.Text))
            {
                txtblock.Text = text;
            }
        }
    }
