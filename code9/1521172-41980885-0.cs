    public abstract class ComplexConverterBase : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Complex) || objectType == typeof(Complex?);
        }
    }
    public class ComplexArrayConverter : ComplexConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var array = serializer.Deserialize<double[]>(reader);
            if (array.Length != 2)
            {
                throw new JsonSerializationException(string.Format("Invalid complex number array of length {0}", array.Length));
            }
            return new Complex(array[0], array[1]);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var complex = (Complex)value;
            writer.WriteStartArray();
            writer.WriteValue(complex.Real);
            writer.WriteValue(complex.Imaginary);
            writer.WriteEndArray();
        }
    }
    public class ComplexObjectConverter : ComplexConverterBase
    {
        // By using a surrogate type, we respect the naming conventions of the serializer's contract resolver.
        class ComplexSurrogate
        {
            public double Real { get; set; }
            public double Imaginary { get; set; }
            public static implicit operator Complex(ComplexSurrogate surrogate)
            {
                if (surrogate == null)
                    return default(Complex);
                return new Complex(surrogate.Real, surrogate.Imaginary);
            }
            public static implicit operator ComplexSurrogate(Complex complex)
            {
                return new ComplexSurrogate { Real = complex.Real, Imaginary = complex.Imaginary };
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            return (Complex)serializer.Deserialize<ComplexSurrogate>(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (ComplexSurrogate)(Complex)value);
        }
    }
    public class ComplexMathJSConverter : ComplexConverterBase
    {
        // Serialize in math.js format
        // http://mathjs.org/docs/core/serialization.html
        // By using a surrogate type, we respect the naming conventions of the serializer's contract resolver.
        class ComplexSurrogate
        {
            [JsonProperty(Order = 1)]
            public double re { get; set; }
            [JsonProperty(Order = 2)]
            public double im { get; set; }
            [JsonProperty(Order = 0)]
            public string mathjs { get { return "Complex"; } }
            public static implicit operator Complex(ComplexSurrogate surrogate)
            {
                if (surrogate == null)
                    return default(Complex);
                return new Complex(surrogate.re, surrogate.im);
            }
            public static implicit operator ComplexSurrogate(Complex complex)
            {
                return new ComplexSurrogate { re = complex.Real, im = complex.Imaginary };
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            return (Complex)serializer.Deserialize<ComplexSurrogate>(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (ComplexSurrogate)(Complex)value);
        }
    }
