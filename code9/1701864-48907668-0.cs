    public class AutoCompleteView
    {
        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(AutoCompleteView), Color.White);
    
        public Color PlaceholderColor
        {
            get
            {
                return (Color)GetValue(PlaceholderColorProperty);
            }
            set
            {
                SetValue(PlaceholderColorProperty, value);
            }
        }
    }
