    /// <summary>
    /// Sets up the swagger documentation for the optional property
    /// </summary>
    public static class SwaggerOptionalPropertyFilter
    {
        /// <summary>
        /// Get the action that applies the swagger documentation for the optional property
        /// </summary>
        public static Action<SwaggerDocument, HttpRequest> GetFilter()
        {
            return (document, request) =>
            {
                foreach (var kvp in document.Definitions)
                {
                    if (!kvp.Key.Contains("OptionalProperty")) continue;
                    var val = kvp.Value.Properties.Values.FirstOrDefault();
                    if (val == null) continue;
                    foreach (var pi in typeof(Schema).GetProperties())
                        pi.SetValue(kvp.Value, pi.GetValue(val, null), null);
                }
            };
        }
    }
