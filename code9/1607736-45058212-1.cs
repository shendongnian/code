    public class CarModel
    {
        // I stick with C# UpperCamelCaseConvention and use Newtonsoft's serializer
        // settings to do the conversions for me.
        public IEnumerable<IEnumerable<string>> Data { get; set; }
    }
