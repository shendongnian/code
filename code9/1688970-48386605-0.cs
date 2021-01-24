      public class AttachedProperties
        {
            public static readonly DependencyProperty SetLanguageProperty =
                    DependencyProperty.RegisterAttached("SetLanguage", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false, OnSetLanguageChanged));
    
            private static void OnSetLanguageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                (d as DatePicker).Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
            }
            public static bool GetSetLanguage(DependencyObject obj)
            {
                return (bool)obj.GetValue(SetLanguageProperty);
            }
            public static void SetSetLanguage(DependencyObject obj, bool value)
            {
                obj.SetValue(SetLanguageProperty, value);
            }
        }
