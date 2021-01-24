    public class MyToggleButton : ToggleButton
    {
        static MyToggleButton()
        {
            MyToggleButton.DefaultStyleKeyProperty.OverrideMetadata(typeof(MyToggleButton), new FrameworkPropertyMetadata(typeof(MyToggleButton)));
        }
        public Brush ToggledBackground
        {
            get { return (Brush)GetValue(ToggledBackgroundProperty); }
            set { SetValue(ToggledBackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ToggledBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggledBackgroundProperty =
            DependencyProperty.Register("ToggledBackground", typeof(Brush), typeof(MyToggleButton), new FrameworkPropertyMetadata());
    }
