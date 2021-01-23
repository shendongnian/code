    public class CultureBinding : System.Windows.Data.Binding
    {
        public CultureBinding(string path) : base(path)
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }
        public CultureBinding()
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }
    }
