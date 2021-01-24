     public class SomeClass
     {
        public static DependencyProperty AdditionalInfoProperty = DependencyProperty.RegisterAttached("AdditionalInfo", typeof(string),typeof(SomeClass),new PropertyMetadata(null));
        public static void SetAdditionalInfo(DependencyObject obj, string value)
        {
            obj.SetValue(AdditionalInfoProperty, value);
        }
        public static string GetAdditionalInfo(DependencyObject obj)
        {
            return (string)obj.GetValue(AdditionalInfoProperty);
        }
    }
