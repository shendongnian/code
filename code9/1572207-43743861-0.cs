    public class AmountDetailsIndexer : MarkupExtension, IValueConverter
    {
        public AmountDetailsIndexer(CalculationType ctype, AmountSource asource)
        {
            CalculationType = ctype;
            AmountSource = asource;
        }
        protected CalculationType CalculationType;
        protected AmountSource AmountSource;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(Object value, Type type, Object converterParameter, System.Globalization.CultureInfo cultureInfo)
        {
            var details = value as AmountDetails;
            return details[CalculationType, AmountSource];
        }
        public object ConvertBack(Object value, Type type, Object converterParameter, System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
