    public class AmountDetailsIndexer : MarkupExtension, IValueConverter
    {
        public AmountDetailsIndexer()
        {
        }
        public AmountDetailsIndexer(CalculationType ctype, AmountSource asource)
        {
            CalculationType = ctype;
            AmountSource = asource;
        }
        public CalculationType CalculationType { get; set; }
        public AmountSource AmountSource { get; set; }
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
