    public class NewTextBox : TextBox
    {
    
        static NewTextBox()
        {
            TextBox.TextProperty.OverrideMetadata(typeof(NewTextBox),
                new FrameworkPropertyMetadata(
                    "n/a",
                    TextBox.TextProperty.DefaultMetadata.PropertyChangedCallback,
                    new CoerceValueCallback(textValueCallback)));
        }
    
        private static object textValueCallback(DependencyObject d, object baseValue)
        {
            return baseValue.ToString().Replace(' ', '.');
        }
    
        public new string Text
        {
            get { return base.Text.Replace('.', ' '); }
        }
    
    }
