    public class SimleSampleClass
    {
        [XmlElement]
        public decimal Something { get; set; }
        [XmlIgnore]
        public bool SomethingSpecified { get; set; }
    }
    [XmlRoot("RootClass")]
    public class RootClass
    {
        [XmlArray]
        [XmlArrayItem("SampleClass")]
        public List<SampleClass> SampleClasses { get; set; }
    }
    [XmlRoot("SampleClass")]
    public class SampleClass
    {
        [XmlAttribute]
        public long Id { get; set; }
        public decimal Something { get; set; }
        [XmlIgnore]
        public bool SomethingSpecified { get; set; }
        public SomeEnum SomeEnum { get; set; }
        [XmlIgnore]
        public bool SomeEnumSpecified { get; set; }
        public string SomeString { get; set; }
        [XmlIgnore]
        public bool SomeStringSpecified { get; set; }
        public decimal? SomeNullable { get; set; }
        [XmlIgnore]
        public bool SomeNullableSpecified { get; set; }
        public DateTime SomeDateTime { get; set; }
        [XmlIgnore]
        public bool SomeDateTimeSpecified { get; set; }
        // https://stackoverflow.com/questions/3280362/most-elegant-xml-serialization-of-color-structure
        [XmlElement(Type = typeof(XmlColor))]
        public Color MyColor { get; set; }
        [XmlIgnore]
        public bool MyColorSpecified { get; set; }
    }
    public enum SomeEnum
    {
        DefaultValue,
        FirstValue,
        SecondValue,
        ThirdValue,
    }
    // https://stackoverflow.com/questions/3280362/most-elegant-xml-serialization-of-color-structure
    public struct XmlColor
    {
        private Color? color_;
        private Color Color
        {
            get
            {
                return color_ ?? Color.Black;
            }
            set
            {
                color_ = value;
            }
        }
        public XmlColor(Color c) { color_ = c; }
        public Color ToColor()
        {
            return Color;
        }
        public void FromColor(Color c)
        {
            Color = c;
        }
        public static implicit operator Color(XmlColor x)
        {
            return x.ToColor();
        }
        public static implicit operator XmlColor(Color c)
        {
            return new XmlColor(c);
        }
        [XmlAttribute]
        public string Web
        {
            get { return ColorTranslator.ToHtml(Color); }
            set
            {
                try
                {
                    if (Alpha == 0xFF) // preserve named color value if possible
                        Color = ColorTranslator.FromHtml(value);
                    else
                        Color = Color.FromArgb(Alpha, ColorTranslator.FromHtml(value));
                }
                catch (Exception)
                {
                    Color = Color.Black;
                }
            }
        }
        [XmlAttribute]
        public byte Alpha
        {
            get { return Color.A; }
            set
            {
                if (value != Color.A) // avoid hammering named color if no alpha change
                    Color = Color.FromArgb(value, Color);
            }
        }
        public bool ShouldSerializeAlpha() { return Alpha < 0xFF; }
    }
