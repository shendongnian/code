    public class AdvancedButton : Button
    {
        public static readonly DependencyProperty IconContentProperty =
          DependencyProperty.Register("Icon", typeof(string), typeof(AdvancedButton), new PropertyMetadata(default(FontIcon)));
        public string Icon
        {
            get { return (string)GetValue(IconContentProperty); }
            set { SetValue(IconContentProperty, value); }
        }
    }
