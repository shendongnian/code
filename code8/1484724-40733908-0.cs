    public class TestConverter : JsonConverter
    {
        #region Overrides of JsonConverter
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object value = new object();     
            if (reader.TokenType != JsonToken.Null)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    JToken token = JToken.Load(reader);
                    List<object> resultado = new List<object>();
                    foreach (var Value in token)
                    {
                        switch (Value.Type)
                        {
                            case JTokenType.Integer:
                                value = Convert.ToInt32(Value);
                                resultado.Add(value);
                                break;
                            case JTokenType.Float:
                                value = Convert.ToDecimal(Value);
                                resultado.Add(value);
                                break;
                            case JTokenType.String:
                                value = Convert.ToString(Value);
                                resultado.Add(value);
                                break;
                            case JTokenType.Boolean:
                                value = Convert.ToBoolean(Value);
                                resultado.Add(value);
                                break;
                            case JTokenType.Null:
                                value = null;
                                resultado.Add(value);
                                break;
                            case JTokenType.Date:
                                value = Convert.ToDateTime(Value);
                                resultado.Add(value);
                                break;
                            case JTokenType.Bytes:
                                value = Convert.ToByte(Value);
                                resultado.Add(value);
                                break;
                            default:
                                Console.WriteLine("Default case");
                                Console.WriteLine(reader.TokenType.ToString());
                                break;
                        }
                    }
                    value = resultado.ToArray();
                }
                else
                {
                    JValue jValue = new JValue(reader.Value);
                    switch (reader.TokenType)
                    {
                        case JsonToken.Integer:
                            value = Convert.ToInt32(reader.Value);
                            break;
                        case JsonToken.Float:
                            value = Convert.ToDecimal(reader.Value);
                            break;
                        case JsonToken.String:
                            value = Convert.ToString(reader.Value);
                            break;
                        case JsonToken.Boolean:
                            value = Convert.ToBoolean(reader.Value);
                            break;
                        case JsonToken.Null:
                            value = null;
                            break;
                        case JsonToken.Date:
                            value = Convert.ToDateTime(reader.Value);
                            break;
                        case JsonToken.Bytes:
                            value = Convert.ToByte(reader.Value);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            Console.WriteLine(reader.TokenType.ToString());
                            break;
                    }
                }
            }
            return value;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object);
        }
        #endregion
    }
