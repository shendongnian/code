        private string ConvertTokenToXmlValue(JsonReader reader)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return (reader.Value != null) ? reader.Value.ToString() : null;
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
        #if !(NET20 || NET35 || PORTABLE || PORTABLE40)
                if (reader.Value is BigInteger)
                {
                    return ((BigInteger)reader.Value).ToString(CultureInfo.InvariantCulture);
                }
        #endif
                return XmlConvert.ToString(Convert.ToInt64(reader.Value, CultureInfo.InvariantCulture));
            }
            else if (reader.TokenType == JsonToken.Float)
            {
                if (reader.Value is decimal)
                {
                    return XmlConvert.ToString((decimal)reader.Value);
                }
                if (reader.Value is float)
                {
                    return XmlConvert.ToString((float)reader.Value);
                }
                return XmlConvert.ToString(Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture));
            }
            else if (reader.TokenType == JsonToken.Boolean)
            {
                return XmlConvert.ToString(Convert.ToBoolean(reader.Value, CultureInfo.InvariantCulture));
            }
            else if (reader.TokenType == JsonToken.Date)
            {
        #if !NET20
                if (reader.Value is DateTimeOffset)
                {
                    return XmlConvert.ToString((DateTimeOffset)reader.Value);
                }
        #endif
                DateTime d = Convert.ToDateTime(reader.Value, CultureInfo.InvariantCulture);
        #if !PORTABLE
                return XmlConvert.ToString(d, DateTimeUtils.ToSerializationMode(d.Kind));
        #else
                return XmlConvert.ToString(d);
        #endif
            }
            else if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            else
            {
                throw JsonSerializationException.Create(reader, "Cannot get an XML string value from token type '{0}'.".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
            }
        }
    Which has a lot of logic for converting a JSON token value to an XML value and is doing the right thing when converting your dates and times to XML.
