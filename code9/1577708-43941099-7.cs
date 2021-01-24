    public class CustomTextBox : TextBox
    {
        #region Number Property
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register(nameof(Number), typeof(int), typeof(CustomTextBox),
                new PropertyMetadata(0));
        #endregion Number Property
        #region Seconds Property
        public int Seconds
        {
            get { return (int)GetValue(SecondsProperty); }
            set { SetValue(SecondsProperty, value); }
        }
        public static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register(nameof(Seconds), typeof(int), typeof(CustomTextBox),
                new PropertyMetadata(0));
        #endregion Seconds Property
    }
