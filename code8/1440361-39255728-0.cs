    public class HintTextBox : TextBox
    {
        public static DependencyProperty HintTextProperty = DependencyProperty.Register("HintText", typeof(string), typeof(HintTextBox));
        
        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }
        static HintTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintTextBox), new FrameworkPropertyMetadata(typeof(HintTextBox)));
        }
    }
