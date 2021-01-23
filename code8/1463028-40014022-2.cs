    namespace YourNamespace
    {
        public class BgHelper
        {
            #region Fields
            public static DependencyProperty CustomBackgroundProperty =
                DependencyProperty.RegisterAttached("CustomBackground",
                                                    typeof (SolidColorBrush),
                                                    typeof (BgHelper),
                                                    new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Transparent)));
            #endregion
        
            #region Public Methods
            public static SolidColorBrush GetCustomBackground(DependencyObject element)
            {
                return (SolidColorBrush) element.GetValue(CustomBackgroundProperty);
            }
            public static void SetCustomBackground(DependencyObject element, SolidColorBrush value)
            {
                element.SetValue(CustomBackgroundProperty, value);
            }
            #endregion
        }
    }
