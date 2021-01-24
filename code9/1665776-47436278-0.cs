    public class TouchTextBoxHelper
    {
        public static readonly DependencyProperty IsTouchKeyboardTargetProperty =
            DependencyProperty.RegisterAttached(
                "IsTouchKeyboardTarget",
                typeof(bool),
                typeof(TouchTextBoxHelper),
                new FrameworkPropertyMetadata(false, IsTouchKeyboardTargetChanged));
        ...
    }
