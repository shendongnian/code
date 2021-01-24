        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            // Int32 implements the IConvertible interface which has a ToString() overload
            // that takes an IFormatProvider specification.  Pass the invariant format to guarantee
            // identical serialization in all cultures.
            var convertible = (IConvertible)value;
            serializer.Serialize(writer, convertible.ToString(NumberFormatInfo.InvariantInfo));
        }
