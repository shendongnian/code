    public class TextboxWithPreview : TextBox
    {
        public static DependencyProperty TextPreviewProperty = DependencyProperty.Register("TextPreview", typeof(string), typeof(TextboxWithPreview));
        
        public string TextPreview
        {
            get { return (string)GetValue(TextPreviewProperty); }
            set { SetValue(TextPreviewProperty, value); }
        }
        static TextboxWithPreview()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextboxWithPreview), new FrameworkPropertyMetadata(typeof(TextboxWithPreview)));
        }
    }
