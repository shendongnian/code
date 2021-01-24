    public class BooleanToBrushConverter : ValueConverterBase
    {
        public Brush TrueBrush { get; set; }
        public Brush FalseBrush { get; set; }
        public Brush DefaultBrush { get; set; }
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value==null)
                {
                    return null;
                }
                var booleanValue = (bool)value;
                return booleanValue ? this.TrueBrush : this.FalseBrush;
            }
            catch (InvalidCastException)
            {
                return this.DefaultBrush;
            }
        }
    }
