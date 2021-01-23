    public class DummyConverter : MarkupExtension, IValueConverter
    {
        private static DummyConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
            {
                _converter = new DummyConverter();
            }
            return _converter;
        }
        #region IValueConverter Members
        ...
        #endregion
    }
