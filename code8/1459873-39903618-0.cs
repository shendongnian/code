    public class CButton : Button
    {
        public static readonly DependencyProperty IsEnabled;
    
        static CButton()
        {
            IsEnabled = UIElement.IsEnabledProperty.AddOwner(typeof(CButton), 
                    new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, 
                        UIElement.IsEnabledProperty.DefaultMetadata.PropertyChangedCallback,
                        new CoerceValueCallback(IsEnabledCoerceCallback)));
        }
    
        private static object IsEnabledCoerceCallback(DependencyObject d, object baseValue)
        {            
            return (bool) baseValue;
        }
    }
