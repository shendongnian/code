    class DataSetFieldTypeConverter : JsonConverter
    {
        private Type convertTo;
        private string tableName;
        private string fieldName;
        public DataSetFieldTypeConverter(Type convertTo, string tableName, string fieldName)
        {
            this.convertTo = convertTo;
            this.tableName = tableName;
            this.fieldName = fieldName;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject jsonObj = t as JObject;
                if (jsonObj != null && jsonObj[tableName] != null && jsonObj[tableName][0][fieldName] != null)
                {
                    var propVal= jsonObj[tableName][0][fieldName].Value<string>();
                    //Write your own covert logic here
                    if (convertTo == typeof(int))
                    {
                        int propValInt;
                        if (int.TryParse(propVal, out propValInt))
                        {
                            jsonObj[tableName][0][fieldName] = propValInt;
                        }
                    }
                    if (convertTo == typeof(double))
                    {
                        double propValInt;
                        if (double.TryParse(propVal, out propValInt))
                        {
                            jsonObj[tableName][0][fieldName] = propValInt;
                        }
                    }
                    jsonObj.WriteTo(writer);
                }
            }
        }
