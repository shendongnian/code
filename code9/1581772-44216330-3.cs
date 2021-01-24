    using MongoDB.Integrations.JsonDotNet.Converters;
    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                // Adds automatic json parsing to BsonDocuments.
                options.SerializerSettings.Converters.Add(new BsonArrayConverter());
                options.SerializerSettings.Converters.Add(new BsonMinKeyConverter());
                options.SerializerSettings.Converters.Add(new BsonBinaryDataConverter());
                options.SerializerSettings.Converters.Add(new BsonNullConverter());
                options.SerializerSettings.Converters.Add(new BsonBooleanConverter());
                options.SerializerSettings.Converters.Add(new BsonObjectIdConverter());
                options.SerializerSettings.Converters.Add(new BsonDateTimeConverter());
                options.SerializerSettings.Converters.Add(new BsonRegularExpressionConverter());
                options.SerializerSettings.Converters.Add(new BsonDocumentConverter());
                options.SerializerSettings.Converters.Add(new BsonStringConverter());
                options.SerializerSettings.Converters.Add(new BsonDoubleConverter());
                options.SerializerSettings.Converters.Add(new BsonSymbolConverter());
                options.SerializerSettings.Converters.Add(new BsonInt32Converter());
                options.SerializerSettings.Converters.Add(new BsonTimestampConverter());
                options.SerializerSettings.Converters.Add(new BsonInt64Converter());
                options.SerializerSettings.Converters.Add(new BsonUndefinedConverter());
                options.SerializerSettings.Converters.Add(new BsonJavaScriptConverter());
                options.SerializerSettings.Converters.Add(new BsonValueConverter());
                options.SerializerSettings.Converters.Add(new BsonJavaScriptWithScopeConverter());
                options.SerializerSettings.Converters.Add(new BsonMaxKeyConverter());
                options.SerializerSettings.Converters.Add(new ObjectIdConverter());
            }); 
        }
    }
