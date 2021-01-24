    public class PropertyViewerTextBox : TextBox
    {
        public object Item
        {
            get { return (object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }
    
        public PropertyViewerTextBox()
        {
            this.TextWrapping = TextWrapping.Wrap;
            this.AcceptsReturn = true;
        }
    
        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(object), typeof(PropertyViewerTextBox), new PropertyMetadata(OnItemChanged));
    
        public static void OnItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textbox = sender as PropertyViewerTextBox;
            if (null == e.NewValue)
            {
                textbox.Text = string.Empty;
                return;
            }
    
            var props = e.NewValue.GetType().GetProperties();
            var text = new StringBuilder();
            foreach(var prop in props)
            {
                text.AppendFormat("{0}{1}", prop.Name, Environment.NewLine);
            }
               
            textbox.Text = text.ToString();
        }
    }
