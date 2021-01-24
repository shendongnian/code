        class UnixConvert : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var time = ToUnixTimestamp((DateTime) value);
                writer.WriteValue(time);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                long unixTimeStamp = long.Parse(reader.Value.ToString());
                return UnixTimeStampToDateTime(unixTimeStamp);
            }
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
            private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
            {
                System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
                return dtDateTime;
            }
            public static long ToUnixTimestamp(DateTime time)
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, time.Kind);
                var unixTimestamp = System.Convert.ToInt64((time - date).TotalSeconds);
                return unixTimestamp;
            }
        }
