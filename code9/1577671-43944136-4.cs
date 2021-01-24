    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.Primitives;
    using Newtonsoft.Json;
    ...
    public class NamedFormatJsonOutputFormatter : JsonOutputFormatter
    {
        private readonly IDictionary<string, JsonSerializerSettings> _customJsonSettings;
        private readonly IDictionary<string, JsonSerializer> _customSerializers;
        public NamedFormatJsonOutputFormatter(JsonSerializerSettings defaultSerializerSettings, IDictionary<string, JsonSerializerSettings> customJsonSettings, ArrayPool<char> charPool) : base (defaultSerializerSettings, charPool)
        {
            _customJsonSettings = customJsonSettings;
            _customSerializers = new Dictionary<string, JsonSerializer>();
        }
        protected virtual JsonSerializer CreateCustomJsonSerializer(string serializerName)
        {
            JsonSerializer outputSerializer;
            var exists = _customSerializers.TryGetValue(serializerName, out outputSerializer);
            if (!exists)
            {
                var settings = _customJsonSettings[serializerName];
                outputSerializer = JsonSerializer.Create(settings);
                _customSerializers[serializerName] = outputSerializer;
            }
            return _customSerializers[serializerName];
        }
        public void WriteObjectWithNamedSerializer(TextWriter writer, string serializerName, object value)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
    
            using (var jsonWriter = CreateJsonWriter(writer))
            {
                var jsonSerializer = CreateCustomJsonSerializer(serializerName);
                jsonSerializer.Serialize(jsonWriter, value);
            }
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var jsonSerializerNameHeader = context.HttpContext.Request.Headers.FirstOrDefault(h => h.Key == "jsonformat" && h.Value.Intersect(_customJsonSettings.Keys).Any());
            if (jsonSerializerNameHeader.Equals(default(KeyValuePair<string, StringValues>)))
            {
                await base.WriteResponseBodyAsync(context, selectedEncoding);
                return;
            }
            var jsonFormatName = jsonSerializerNameHeader.Value.FirstOrDefault();
    
            var response = context.HttpContext.Response;
            using (var writer = context.WriterFactory(response.Body, selectedEncoding))
            {
                WriteObjectWithNamedSerializer(writer, jsonFormatName, context.Object);
                await writer.FlushAsync();
            }
        }
    }
