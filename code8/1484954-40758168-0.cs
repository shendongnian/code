    public class CustomTextBox : TextBox
    {
        static CustomTextBox()
        {
            TextProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(null, null, CoerceChanged));
        }
        private static object CoerceChanged(DependencyObject d, object basevalue)
        {
            var tb = d as TextBox;
            if (basevalue == null)
            {
                return tb.Text;
            }
            return basevalue;
        }
    }
