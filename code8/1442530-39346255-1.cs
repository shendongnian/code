    public class DiffTextBlock : TextBlock
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(DiffTextBlock), new UIPropertyMetadata(null, new PropertyChangedCallback(OnContentChanged)));
        public string Value
        {
            get { return GetValue(ValueProperty) as string; }
            set { SetValue(ValueProperty, value); }
        }
        static void OnContentChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            DiffTextBlock control = target as DiffTextBlock;
            control.createParts(e.NewValue as string);
        }
        void createParts(string text)
        {
            this.Text = "";
            Inlines.Clear();
            // Inlines.Add(text);
            // this.Text = text;
            // Here I write my own algorithm for determine which characters highlight
        }
    }
