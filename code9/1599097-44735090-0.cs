    public Dictionary<string, string> GetAllResources(string culture){
            var result = new Dictionary<string, string>();
            // let's point somehow to our assembly which contains all resource files
            var resourceAssembly = Assembly.GetAssembly(typeof(EnumsResource));
            var resourceTypes = resourceAssembly
                .GetTypes()
                .Where(e => e.Name.EndsWith("Resource"));
            // Culture
            var cultureInfo = new CultureInfo(culture);
            foreach (var resourceType in resourceTypes)
            {
                var resourceManager = (ResourceManager)resourceType.GetProperty("ResourceManager").GetValue(null);
                var resourceName = resourceManager.BaseName.Split('.').Last();
                var resourceSet = resourceManager.GetResourceSet(cultureInfo, true, true);
                foreach (DictionaryEntry entry in resourceSet)
                {
                    var resourceKey = $"{resourceName}.{entry.Key}".ToLower();
                    var resource = entry.Value.ToString();
                    if (!result.ContainsKey(resourceKey))
                    {
                        result.Add(resourceKey, resource);
                    }
                }
            }
            return result;
    }
