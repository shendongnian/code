    class Animal
    {
        public int Type { get; set; }
        public int ObjectId { get; set; }
        public string DeviceType { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        /// <summary>
        /// Parses an input string and returns an Animal based
        /// on any property values found in the string
        /// </summary>
        /// <param name="input">The string to parse for property values</param>
        /// <returns>An animal instance with specified properties</returns>
        public static Animal Parse(string input)
        {
            var result = new Animal();
            if (string.IsNullOrWhiteSpace(input)) return result;
            // Parse input string and set fields accordingly
            var keyValueParts = input
                .Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(kvp => kvp.Trim());
            foreach (var keyValuePart in keyValueParts)
            {
                if (keyValuePart.StartsWith("Type", 
                    StringComparison.OrdinalIgnoreCase))
                {
                    int type;
                    var value = keyValuePart.Substring("Type".Length).Trim();
                    if (int.TryParse(value, out type))
                    {
                        result.Type = type;
                    }
                }
                else if (keyValuePart.StartsWith("Object Id", 
                    StringComparison.OrdinalIgnoreCase))
                {
                    int objectId;
                    var value = keyValuePart.Substring("Object Id".Length).Trim();
                    if (int.TryParse(value, out objectId))
                    {
                        result.ObjectId = objectId;
                    }
                }
                else if (keyValuePart.StartsWith("Device Type", 
                    StringComparison.OrdinalIgnoreCase))
                {
                    var value = keyValuePart.Substring("Device Type".Length).Trim();
                    result.DeviceType = value;
                }
                else if (keyValuePart.StartsWith("Tag", 
                    StringComparison.OrdinalIgnoreCase))
                {
                    var value = keyValuePart.Substring("Tag".Length).Trim();
                    result.Tag = value;
                }
                else if (keyValuePart.StartsWith("Description", 
                    StringComparison.OrdinalIgnoreCase))
                {
                    var value = keyValuePart.Substring("Description".Length).Trim();
                    result.Description = value;
                }
                else if (keyValuePart.StartsWith("Units", 
                    StringComparison.OrdinalIgnoreCase))
                {
                    var value = keyValuePart.Substring("Units".Length).Trim();
                    result.Units = value;
                }
            }
            return result;            
        }
        public override string ToString()
        {
            // Return a string that describes this animal
            var animalProperties = new StringBuilder();
            animalProperties.Append($"Type = {Type}, Object Id = {ObjectId}, ");
            animalProperties.Append($"Device Type = {DeviceType}, Tag = {Tag}, ");
            animalProperties.Append($"Description = {Description}, Units = {Units}");
            return animalProperties.ToString();
        }
    }
