    public static class SliderExtensions
    {
        public static string GetLeftLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LeftLabelProperty);
        }
        public static void SetLeftLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LeftLabelProperty, value);
        }
        public static readonly DependencyProperty LeftLabelProperty = DependencyProperty.RegisterAttached(
            "LeftLabel",
            typeof(string),
            typeof(SliderExtensions)
        );
        public static string GetRightLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(RightLabelProperty);
        }
        public static void SetRightLabel(DependencyObject obj, string value)
        {
            obj.SetValue(RightLabelProperty, value);
        }
        public static readonly DependencyProperty RightLabelProperty = DependencyProperty.RegisterAttached(
            "RightLabel",
            typeof(string),
            typeof(SliderExtensions)
        );
    }
