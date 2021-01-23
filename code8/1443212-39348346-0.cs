    public class ImageProperties
    {
        public static readonly DependencyProperty ByteEncodedStringProperty = DependencyProperty.RegisterAttached("ByteEncodedString", typeof(string), typeof(ImageProperties), new PropertyMetadata(null, ByteEncodedStringPropertyChanged));
    
        private static void ByteEncodedStringPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Image image = sender as Image;
    
            if (image != null)
            {
                ImageSource imageSource = DecodeByteEncodedStringImage(args.NewValue);
    
                image.Source = imageSource;
            }
        }
    
        public static string GetByteEncodedString(DependencyObject obj)
        {
            return (string)obj.GetValue(ByteEncodedStringProperty);
        }
    
        public static void SetByteEncodedString(DependencyObject obj, string value)
        {
            obj.SetValue(ByteEncodedStringProperty, value);
        }
    }
