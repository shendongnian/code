    public class Test
    {
        [TypeConverter(typeof(ConverterArray))]
        public string[] Property { get; set; } = new[] { "1", "2", "3" };
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = new Test();
        }
    }
    public class ConverterArray : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string))
                return "An array kk?";
            return base.ConvertTo(context, culture, value, destType);
        }
    }
