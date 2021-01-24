    public class MyCustomSlider : Slider
    {
        public string LeftLabel
        {
            get { return (string)GetValue(LeftLabelProperty); }
            set { SetValue(LeftLabelProperty, value); }
        }
        public static readonly DependencyProperty LeftLabelProperty = DependencyProperty.Register(
            nameof(LeftLabel),
            typeof(string),
            typeof(MyCustomSlider)
        );
        public string RightLabel
        {
            get { return (string)GetValue(RightLabelProperty); }
            set { SetValue(RightLabelProperty, value); }
        }
        public static readonly DependencyProperty RightLabelProperty = DependencyProperty.Register(
            nameof(RightLabel),
            typeof(string),
            typeof(MyCustomSlider)
        );
    }
