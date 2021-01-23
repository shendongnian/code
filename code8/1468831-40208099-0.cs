    [ValueConversion(typeof(object), typeof(ImageSource))]
    public class CustomImageConverter : IValueConverter
    {
        public object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            ImageSource ReturnSource = null;
    
            if (Value != null)
            {
                Type SourceType = Value.GetType();
    
                if (SourceType == typeof(byte[]))
                {
                    //Your implementation of byte[] to ImageSource
                    ReturnSource = ...;
                }
                else if (SourceType == typeof(Stream))
                {
                    //Your implementation of Stream to ImageSource
                    ReturnSource = ...;
                } 
                ...          
            }
            return ReturnSource;
        }
    
        public object ConvertBack(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            throw new NotSupportedException();
        }
    }
