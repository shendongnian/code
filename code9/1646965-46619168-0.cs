    static class ValidationExtensions
    {
        public static void ValidateNoUnknownProperties<TValid>(this string json)
        {
            var validPropertyNames = typeof(TValid).GetProperties().Select(p => p.Name).ToList();
            var deserializedJson = JObject.Parse(json);
            var invalidPropertyNames = deserializedJson.Properties()
                                           .Where(p => !validPropertyNames.Contains(p.Name))
                                           .Select(p => p.Name)
                                           .ToList();
                                                           
            if (invalidPropertyNames.Count() > 0)
            {
                throw new Exception($"Invalid Properties: {string.Join(",", invalidPropertyNames)}");
            }
        }
    }
