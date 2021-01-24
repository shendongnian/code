    [XmlRoot("object")]
    public class RPPProject : RPPItemBase
    {
        public RPPProject() { this.Kind = "project"; }
        [XmlAttribute("states")]
        public string States { get; set; }
        [XmlElement("fields")]
        public RPPProjectFields Fields { get; set; }
    }
    
    [XmlRoot("fields")]
    [DataContract(Name = "fields")]
    public class RPPProjectFields
    {
        [XmlIgnore]
        [DataMember(Name = "coordinate-system-internal")]
        public string CoordinateSystemInternal { get; set; }
        [XmlIgnore]
        [DataMember(Name = "min-longitude")]
        public double MinLongitude { get; set; }
        [XmlIgnore]
        [DataMember(Name = "min-latitude")]
        public double MinLatitude { get; set; }
        [XmlIgnore]
        [DataMember(Name = "min-altitude")]
        public DimensionalValue MinAltitude { get; set; }
        [XmlIgnore]
        [DataMember(Name = "max-longitude")]
        public double MaxLongitude { get; set; }
        [XmlIgnore]
        [DataMember(Name = "max-latitude")]
        public double MaxLatitude { get; set; }
        [XmlIgnore]
        [DataMember(Name = "max-altitude")]
        public DimensionalValue MaxAltitude { get; set; }
        [XmlIgnore]
        [DataMember(Name = "pop")]
        public double[][] Pop { get; set; } //[4][4]
        [XmlIgnore]
        [DataMember(Name = "pop-acquisition")]
        public double[][] PopAcquisition { get; set; } //[4][4]
        [XmlElement("field")]
        public RPPProjectFieldDTO[] Fields
        {
            get
            {
                return this.GetDataContractFields();
            }
            set
            {
                this.SetDataContractFields(value);
            }
        }
    }
    public enum Units
    {
        [XmlEnum("none")]
        None,
        [XmlEnum("m")]
        Meters,
        [XmlEnum("cm")]
        Centimeters,
        [XmlEnum("mm")]
        Millimeters,
    }
    // Going with something like the Money Pattern here:
    // http://www.dsc.ufcg.edu.br/~jacques/cursos/map/recursos/fowler-ap/Analysis%20Pattern%20Quantity.htm
    // You may want to implement addition, subtraction, comparison and so on.
    public struct DimensionalValue
    {
        readonly Units units;
        readonly double value;
        public DimensionalValue(Units units, double value)
        {
            this.units = units;
            this.value = value;
        }
        public Units Units { get { return units; } }
        public double Value { get { return value; } }
    }
    public interface IFieldDTOParser
    {
        Regex Regex { get; }
        bool TryCreateDTO(object obj, out RPPProjectFieldDTO field);
        object Parse(RPPProjectFieldDTO field, Match match);
    }
    class StringParser : IFieldDTOParser
    {
        readonly Regex regex = new Regex("^string$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);
        #region IFieldDTOParser Members
        public Regex Regex { get { return regex; } }
        public bool TryCreateDTO(object obj, out RPPProjectFieldDTO field)
        {
            if (obj is string)
            {
                field = new RPPProjectFieldDTO { Data = (string)obj, Kind = "string"};
                return true;
            }
            field = null;
            return false;
        }
        public object Parse(RPPProjectFieldDTO field, Match match)
        {
            return field.Data;
        }
        #endregion
    }
    class DoubleParser : IFieldDTOParser
    {
        readonly Regex regex = new Regex("^double$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);
        #region IFieldDTOParser Members
        public Regex Regex { get { return regex; } }
        public bool TryCreateDTO(object obj, out RPPProjectFieldDTO field)
        {
            if (obj is double)
            {
                field = new RPPProjectFieldDTO { Data = XmlConvert.ToString((double)obj), Kind = "double"};
                return true;
            }
            else if (obj is DimensionalValue)
            {
                var value = (DimensionalValue)obj;
                field = new RPPProjectFieldDTO { Data = XmlConvert.ToString(value.Value), Kind = "double", Unit = value.Units.ToXmlValue() };
                return true;
            }
            field = null;
            return false;
        }
        public object Parse(RPPProjectFieldDTO field, Match match)
        {
            var value = XmlConvert.ToDouble(field.Data);
            if (string.IsNullOrEmpty(field.Unit))
                return value;
            var unit = field.Unit.FromXmlValue<Units>();
            return new DimensionalValue(unit, value);
        }
        #endregion
    }
    class Double2DArrayParser : IFieldDTOParser
    {
        readonly Regex regex = new Regex("^double\\[([0-9]+)\\]\\[([0-9]+)\\]$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.CultureInvariant);
        #region IFieldDTOParser Members
        public Regex Regex { get { return regex; } }
        public bool TryCreateDTO(object obj, out RPPProjectFieldDTO field)
        {
            if (obj is double[][])
            {
                var value = (double[][])obj;
                var nCols = value.GetLength(0);
                var rowLengths = value.Select(a => a == null ? 0 : a.Length).Distinct().ToArray();
                if (rowLengths.Length == 0)
                {
                    field = new RPPProjectFieldDTO { Data = "", Kind = string.Format("double[{0}][{1}]", XmlConvert.ToString(nCols), "0")};
                    return true;
                }
                else if (rowLengths.Length == 1)
                {
                    field = new RPPProjectFieldDTO 
                    { 
                        Data = String.Join(" ", value.SelectMany(a => a).Select(v => XmlConvert.ToString(v))),
                        Kind = string.Format("double[{0}][{1}]", XmlConvert.ToString(nCols), XmlConvert.ToString(rowLengths[0])) 
                    };
                    return true;
                }
            }
            field = null;
            return false;
        }
        public object Parse(RPPProjectFieldDTO field, Match match)
        {
            var nRows = XmlConvert.ToInt32(match.Groups[1].Value);
            var nCols = XmlConvert.ToInt32(match.Groups[2].Value);
            var array = new double[nRows][];
            var values = field.Data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int iRow = 0, iValue = 0; iRow < nRows; iRow++)
            {
                array[iRow] = new double[nCols];
                for (int iCol = 0; iCol < nCols; iCol++)
                {
                    if (iValue < values.Length)
                        array[iRow][iCol] = XmlConvert.ToDouble(values[iValue++]);
                }
            }
            return array;
        }
        #endregion
    }
    public static class FieldDTOExtensions
    {
        readonly static IFieldDTOParser[] parsers = new IFieldDTOParser[]
        {
            new StringParser(),
            new DoubleParser(),
            new Double2DArrayParser(),
        };
        public static void SetDataContractFields<T>(this T @this, RPPProjectFieldDTO [] value)
        {
            if (value == null)
                return;
            var lookup = value.ToDictionary(f => f.Name, f => f.Parse<object>());
            var query = from p in @this.GetType().GetProperties()
                        where p.CanRead && p.CanWrite && p.GetIndexParameters().Length == 0
                        let a = p.GetCustomAttributes<DataMemberAttribute>().SingleOrDefault()
                        where a != null
                        select new { Property = p, Name = a.Name };
            foreach (var property in query)
            {
                object item;
                if (lookup.TryGetValue(property.Name, out item))
                {
                    property.Property.SetValue(@this, item, null);
                }
            }
        }
        public static RPPProjectFieldDTO[] GetDataContractFields<T>(this T @this)
        {
            var query = from p in @this.GetType().GetProperties()
                        where p.CanRead && p.CanWrite && p.GetIndexParameters().Length == 0
                        let a = p.GetCustomAttributes<DataMemberAttribute>().SingleOrDefault()
                        where a != null
                        let v = p.GetValue(@this, null)
                        where v != null
                        select FieldDTOExtensions.ToDTO(v, a.Name);
            return query.ToArray();
        }
        public static T Parse<T>(this RPPProjectFieldDTO field)
        {
            foreach (var parser in parsers)
            {
                var match = parser.Regex.Match(field.Kind);
                if (match.Success)
                {
                    return (T)parser.Parse(field, match);
                }
            }
            throw new ArgumentException(string.Format("Unsupported object {0}", field.Kind));
        }
        
        public static RPPProjectFieldDTO ToDTO(object obj, string name)
        {
            RPPProjectFieldDTO field;
            foreach (var parser in parsers)
            {
                if (parser.TryCreateDTO(obj, out field))
                {
                    field.Name = name;
                    return field;
                }
            }
            throw new ArgumentException(string.Format("Unsupported object {0}", obj));
        }
    }
    // Taken from 
    // https://stackoverflow.com/questions/42990069/get-element-of-an-enum-by-sending-xmlenumattribute-c
    public static partial class XmlExtensions
    {
        static XmlExtensions()
        {
            noStandardNamespaces = new XmlSerializerNamespaces();
            noStandardNamespaces.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd attributes.
        }
        readonly static XmlSerializerNamespaces noStandardNamespaces;
        internal const string RootNamespace = "XmlExtensions";
        internal const string RootName = "Root";
        public static TEnum FromXmlValue<TEnum>(this string xml) where TEnum : struct, IConvertible, IFormattable
        {
            var element = new XElement(XName.Get(RootName, RootNamespace), xml);
            return element.Deserialize<XmlExtensionsEnumWrapper<TEnum>>(null).Value;
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                object result = (serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
        public static string ToXmlValue<TEnum>(this TEnum value) where TEnum : struct, IConvertible, IFormattable
        {
            var root = new XmlExtensionsEnumWrapper<TEnum> { Value = value };
            return root.SerializeToXElement().Value;
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, noStandardNamespaces); // Disable the xmlns:xsi and xmlns:xsd attributes by default.
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj, ns);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
    }
    [XmlRoot(XmlExtensions.RootName, Namespace = XmlExtensions.RootNamespace)]
    [XmlType(IncludeInSchema = false)]
    public class XmlExtensionsEnumWrapper<TEnum>
    {
        [XmlText]
        public TEnum Value { get; set; }
    }
