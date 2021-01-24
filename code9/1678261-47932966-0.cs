    class DataObject
    {
        public DateTime CreatedDate { get; set; }
    }
    
    class CustomJsonConverter : JsonConverter
    {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var obj = new DataObject();
    
                reader.Read();
                var prop = obj.GetType().GetProperty("CreatedDate");
    
                reader.Read();
                var strDate = (string)reader.Value;
                DateTime date;
                if (DateTime.TryParseExact(strDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    prop.SetValue(obj, date);
                if (DateTime.TryParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    prop.SetValue(obj, date);
    
                return obj;
            }
    }
