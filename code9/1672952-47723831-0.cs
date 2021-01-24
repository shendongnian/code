    class ClimateIndicatorsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ClimateIndicators);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Atmospheric atm = new Atmospheric();
            atm.Pressure = (double)obj.SelectToken("main.pressure");
            atm.Humidity = (int)obj.SelectToken("main.humidity");
            atm.SeaLevel = (double)obj.SelectToken("main.sea_level");
            atm.GroundLevel = (double)obj.SelectToken("main.grnd_level");
            atm.Cloudiness = (int)obj.SelectToken("clouds.all");
            atm.Rain = (double?)obj.SelectToken("rain.3h");
            atm.Snow = (double?)obj.SelectToken("snow.3h");
            ClimateIndicators indicators = new ClimateIndicators();
            indicators.Atmospheric = atm;
            indicators.Date = (DateTime)obj.SelectToken("dt_txt");
            return indicators;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
