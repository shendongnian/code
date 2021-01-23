     public class CustomBodyDeserializer : IBodyDeserializer
    {
        private readonly MethodInfo deserializeMethod = typeof(JavaScriptSerializer).GetMethod("Deserialize", BindingFlags.Instance | BindingFlags.Public);
        private readonly JsonConfiguration jsonConfiguration;
        private readonly GlobalizationConfiguration globalizationConfiguration;
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonBodyDeserializer"/>,
        /// with the provided <paramref name="environment"/>.
        /// </summary>
        /// <param name="environment">An <see cref="INancyEnvironment"/> instance.</param>
        public CustomBodyDeserializer(INancyEnvironment environment)
        {
            this.jsonConfiguration = environment.GetValue<JsonConfiguration>();
            this.globalizationConfiguration = environment.GetValue<GlobalizationConfiguration>();
        }
        /// <summary>
        /// Whether the deserializer can deserialize the content type
        /// </summary>
        /// <param name="mediaRange">Content type to deserialize</param>
        /// <param name="context">Current <see cref="BindingContext"/>.</param>
        /// <returns>True if supported, false otherwise</returns>
        public bool CanDeserialize(MediaRange mediaRange, BindingContext context)
        {
            return Json.IsJsonContentType(mediaRange);
        }
        /// <summary>
        /// Deserialize the request body to a model
        /// </summary>
        /// <param name="mediaRange">Content type to deserialize</param>
        /// <param name="bodyStream">Request body stream</param>
        /// <param name="context">Current context</param>
        /// <returns>Model instance</returns>
        public object Deserialize(MediaRange mediaRange, Stream bodyStream, BindingContext context)
        {            
            //var serializer = new JavaScriptSerializer(this.jsonConfiguration, this.globalizationConfiguration);
            //serializer.RegisterConverters(this.jsonConfiguration.Converters, this.jsonConfiguration.PrimitiveConverters);
            if (bodyStream.CanSeek)
            {
                bodyStream.Position = 0;
            }
            string bodyText;
            using (var bodyReader = new StreamReader(bodyStream))
            {
                bodyText = bodyReader.ReadToEnd();
            }
           // var genericDeserializeMethod = this.deserializeMethod.MakeGenericMethod(context.DestinationType);
           // var deserializedObject = genericDeserializeMethod.Invoke(serializer, new object[] { bodyText });
            object deserializedObject = JsonConvert.DeserializeObject(bodyText, context.DestinationType, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });
            return deserializedObject;
        }
        public void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            string currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }
