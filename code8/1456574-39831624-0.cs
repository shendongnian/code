    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddMvc()
            .AddJsonOptions(option =>
            {
                option.SerializerSettings.Converters.Add(new LeadConverter());
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();
            app.UseMvcWithDefaultRoute();
        }
    }
    public class LeadConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonSerializer = new JsonSerializer
            {
                DateFormatString = "dd.MM.yyyy"
            };
            return jsonSerializer.Deserialize<Lead>(reader);
        }
        public override bool CanConvert(Type objectType) => objectType == typeof(Lead);
    }
