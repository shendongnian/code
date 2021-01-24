    public class SplunkLogTextWriter : JsonWriter
    {
        readonly TextWriter _writer;
        public bool QuotePropertyNames { get; set; }
        public SplunkLogTextWriter(TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException();
            }
            _writer = textWriter;
        }
        public override void Flush()
        {
            _writer.Flush();
        }
        public override void Close()
        {
            base.Close();
            if (CloseOutput)
                _writer.Close();
        }
        public override void WriteComment(string text)
        {
            base.WriteComment(text);
            throw new NotImplementedException();
        }
        public override void WriteRaw(string json)
        {
            base.WriteRaw(json);
            _writer.Write(json);
        }
        public override void WriteStartArray()
        {
            base.WriteStartArray();
            _writer.Write("[ ");
        }
        public override void WriteStartObject()
        {
            base.WriteStartObject();
            _writer.Write("{ ");
        }
        public override void WriteStartConstructor(string name)
        {
            base.WriteStartConstructor(name);
            throw new NotImplementedException();
        }
        protected override void WriteEnd(JsonToken token)
        {
            base.WriteEnd(token);
            switch (token)
            {
                case JsonToken.EndObject:
                    _writer.Write(" }");
                    break;
                case JsonToken.EndArray:
                    _writer.Write(" ]");
                    break;
                case JsonToken.EndConstructor:
                    _writer.Write(" )");
                    break;
                default:
                    throw new JsonWriterException("Invalid JsonToken: " + token);
            }
        }
        public override void WritePropertyName(string name)
        {
            base.WritePropertyName(name);
            WriteEscapedString(name, QuotePropertyNames);
            _writer.Write(" = ");
        }
        void WriteEscapedString(string s, bool quote)
        {
            s = s ?? string.Empty;
            quote = quote || s.Length == 0 || s.Any(c => Char.IsWhiteSpace(c) || c == '=' || c == ']' || c == '}');
            if (quote)
                _writer.Write('"');
            foreach (var c in s)
            {
                switch (c)
                {
                    case '\t':
                        _writer.Write(@"\t");
                        break;
                    case '\n':
                        _writer.Write(@"\n");
                        break;
                    case '\r':
                        _writer.Write(@"\r");
                        break;
                    case '\f':
                        _writer.Write(@"\f");
                        break;
                    case '\b':
                        _writer.Write(@"\b");
                        break;
                    case '\\':
                        _writer.Write(@"\\");
                        break;
                    case '\u0085': // Next Line
                        _writer.Write(@"\u0085");
                        break;
                    case '\u2028': // Line Separator
                        _writer.Write(@"\u2028");
                        break;
                    case '\u2029': // Paragraph Separator
                        _writer.Write(@"\u2029");
                        break;
                    default:
                        _writer.Write(c);
                        break;
                }
            }
            if (quote)
                _writer.Write('"');
        }
        #region WriteValue methods
        public override void WriteNull()
        {
            base.WriteNull();
            _writer.Write("null");
        }
        public override void WriteValue(bool value)
        {
            base.WriteValue(value);
            _writer.Write(value ? "true" : "false");
        }
        public override void WriteValue(byte value)
        {
            base.WriteValue(value);
            WriteIntegerValue((ulong)value);
        }
        public override void WriteValue(byte[] value)
        {
            base.WriteValue(value);
            if (value == null)
                _writer.Write("null");
            else
                WriteEscapedString(Convert.ToBase64String(value), false);
        }
        public override void WriteValue(sbyte value)
        {
            base.WriteValue(value);
            WriteIntegerValue(value);
        }
        public override void WriteValue(char value)
        {
            base.WriteValue(value);
            WriteEscapedString(value.ToString(), false);
        }
        public override void WriteValue(short value)
        {
            base.WriteValue(value);
            WriteIntegerValue(value);
        }
        public override void WriteValue(ushort value)
        {
            base.WriteValue(value);
            WriteIntegerValue((ulong)value);
        }
        public override void WriteValue(int value)
        {
            base.WriteValue(value);
            WriteIntegerValue(value);
        }
        public override void WriteValue(uint value)
        {
            base.WriteValue(value);
            WriteIntegerValue((ulong)value);
        }
        public override void WriteValue(long value)
        {
            base.WriteValue(value);
            WriteIntegerValue(value);
        }
        public override void WriteValue(ulong value)
        {
            base.WriteValue(value);
            WriteIntegerValue(value);
        }
        private void WriteIntegerValue(long value)
        {
            _writer.Write(value.ToString(Culture ?? CultureInfo.InvariantCulture));
        }
        private void WriteIntegerValue(ulong value)
        {
            _writer.Write(value.ToString(Culture ?? CultureInfo.InvariantCulture));
        }
        public override void WriteValue(DateTime value)
        {
            base.WriteValue(value);
            // Use Json.NET to format the date.  Consider replacing with something more performant.
            var s = JsonConvert.ToString(value, DateFormatHandling, DateTimeZoneHandling);
            WriteEscapedString(s.Substring(1, s.Length - 2), false);
        }
        public override void WriteValue(DateTimeOffset value)
        {
            base.WriteValue(value);
            // Use Json.NET to format the date.  Consider replacing with something more performant.
            var s = JsonConvert.ToString(value, DateFormatHandling);
            WriteEscapedString(s.Substring(1, s.Length - 2), false);
        }
        public override void WriteValue(decimal value)
        {
            base.WriteValue(value);
            _writer.Write(value.ToString(Culture ?? CultureInfo.InvariantCulture));
        }
        public override void WriteValue(double value)
        {
            base.WriteValue(value);
            // JsonConvert.ToString(value, FloatFormatHandling, QuoteChar, false) -- not public
            _writer.Write(JsonConvert.ToString(value));
        }
        public override void WriteValue(string value)
        {
            base.WriteValue(value);
            WriteEscapedString(value, false);
        }
        protected override void WriteValueDelimiter()
        {
            base.WriteValueDelimiter();
            _writer.Write(", ");
        }
        public override void WriteUndefined()
        {
            base.WriteUndefined();
            throw new NotImplementedException();
        }
        public override void WriteValue(Guid value)
        {
            base.WriteValue(value);
            throw new NotImplementedException();
        }
        #endregion
        // ToDo
        // WriteIndentSpace()
        // WriteIndent()
        // async methods
        // Others for which I threw a NotImplementedException()
    }
