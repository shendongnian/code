    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple = false)]
    public class JsonFormatAttribute : System.Attribute
    {
        public JsonFormatAttribute(string formattingString)
        {
            this.FormattingString = formattingString;
        }
        /// <summary>
        /// The format string to pass to string.Format()
        /// </summary>
        public string FormattingString { get; set; }
        /// <summary>
        /// The name of the underlying property that returns the object's culture, or NULL if not applicable.
        /// </summary>
        public string CulturePropertyName { get; set; }
    }
    public class FormattedPropertyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization)
                .AddFormatting();
        }
    }
    public static class JsonContractExtensions
    {
        class FormattedValueProvider : IValueProvider
        {
            readonly IValueProvider baseProvider;
            readonly string formatString;
            readonly IValueProvider cultureValueProvider;
            public FormattedValueProvider(IValueProvider baseProvider, string formatString, IValueProvider cultureValueProvider)
            {
                this.baseProvider = baseProvider;
                this.formatString = formatString;
                this.cultureValueProvider = cultureValueProvider;
            }
            #region IValueProvider Members
            public object GetValue(object target)
            {
                var value = baseProvider.GetValue(target);
                var culture = cultureValueProvider == null ? null : (CultureInfo)cultureValueProvider.GetValue(target);
                return string.Format(culture ?? CultureInfo.InvariantCulture, formatString, value);
            }
            public void SetValue(object target, object value)
            {
                // This contract resolver should only be used for serialization, not deserialization, so throw an exception.
                throw new NotImplementedException();
            }
            #endregion
        }
        public static IList<JsonProperty> AddFormatting(this IList<JsonProperty> properties)
        {
            ILookup<string, JsonProperty> lookup = null;
            foreach (var jsonProperty in properties)
            {
                var attr = (JsonFormatAttribute)jsonProperty.AttributeProvider.GetAttributes(typeof(JsonFormatAttribute), false).SingleOrDefault();
                if (attr != null)
                {
                    IValueProvider cultureValueProvider = null;
                    if (attr.CulturePropertyName != null)
                    {
                        if (lookup == null)
                            lookup = properties.ToLookup(p => p.UnderlyingName);
                        var cultureProperty = lookup[attr.CulturePropertyName].FirstOrDefault();
                        if (cultureProperty != null)
                            cultureValueProvider = cultureProperty.ValueProvider;
                    }
                    jsonProperty.ValueProvider = new FormattedValueProvider(jsonProperty.ValueProvider, attr.FormattingString, cultureValueProvider);
                    jsonProperty.PropertyType = typeof(string);
                }
            }
            return properties;
        }
    }
