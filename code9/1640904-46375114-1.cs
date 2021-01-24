    using System.Windows;
    
    namespace MyApplication.AttachedProperties
    {
        public class WindowAttachedProperties
        {
            public static readonly DependencyProperty IsClosedProperty = DependencyProperty.RegisterAttached(
                "IsClosed", typeof(bool), typeof(WindowAttachedProperties), new PropertyMetadata(default(bool), PropertyChangedCallback));
    
            private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
            {
                var window = dependencyObject as Window;
                var isClosed = window?.GetValue(IsClosedProperty) as bool?;
    
                if (window != null && isClosed.GetValueOrDefault())
                {
                    window.Close();
                }
            }
    
            public static void SetIsClosed(DependencyObject element, bool value)
            {
                element.SetValue(IsClosedProperty, value);
            }
    
            public static bool GetIsClosed(DependencyObject element)
            {
                return (bool) element.GetValue(IsClosedProperty);
            }
        }
    }
