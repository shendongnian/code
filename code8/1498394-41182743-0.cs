        public class BindableConverter : Freezable, IValueConverter
        {
            #region Overrides of Freezable    
            protected override Freezable CreateInstanceCore()
            {
                return new BindableConverter();
            }    
            #endregion       
    
            public TextBox SourceTextBox
            {
                get { return (TextBox)GetValue(SourceTextBoxProperty); }
                set { SetValue(SourceTextBoxProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for SourceTextBox.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SourceTextBoxProperty =
                DependencyProperty.Register("SourceTextBox", typeof(TextBox), typeof(BindableConverter), new PropertyMetadata(null));
    
                    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                // ... do something with SourceTextBox here
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                // ... do something
            }
        }
