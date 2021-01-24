    public static class ButtonHelper
    {
        #region ButtonHelper.ButtonImageSource Attached Property
        public static ImageSource GetButtonImageSource(Button obj)
        {
            return (ImageSource)obj.GetValue(ButtonImageSourceProperty);
        }
        public static void SetButtonImageSource(Button obj, ImageSource value)
        {
            obj.SetValue(ButtonImageSourceProperty, value);
        }
        public static readonly DependencyProperty ButtonImageSourceProperty =
            DependencyProperty.RegisterAttached("ButtonImageSource", typeof(ImageSource), typeof(ButtonHelper),
                new PropertyMetadata(null));
        #endregion ButtonHelper.ButtonImageSource Attached Property
    }
