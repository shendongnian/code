       public static class ResourceWrapper
        {
            private static Dictionary<string, ResourceSet> ResourceSets = new Dictionary<string, ResourceSet>();
    
            private const string DEFAULT_LANGUAGE_VALUE = "default";
    
            static ResourceWrapper()
            {
                try
                {
                    ResourceSets.Add(DEFAULT_LANGUAGE_VALUE, new ResourceSet(Assembly.GetExecutingAssembly().GetManifestResourceStream("Function.Logic.Resources.Resource.resources")));
                }
                catch { }
            }
    
            public static void Load(string lang)
            {
                if (string.IsNullOrEmpty(lang) || ResourceSets.ContainsKey(lang))
                {
                    return;
                }
    
                lock (new object())
                {
                    if (ResourceSets.ContainsKey(lang))
                    {
                        return;
                    }
    
                    try
                    {
                        string rootPath = Environment.CurrentDirectory;
    
                        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                        {
                            rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\";
                        }
    
                        var asm = Assembly.LoadFrom(Path.Combine(rootPath, "bin", lang, "Function.Logic.resources.dll"));
                        var resourceName = $"Function.Logic.Resources.Resource.{lang}.resources";
                        ResourceSets.Add(lang, new ResourceSet(asm.GetManifestResourceStream(resourceName)));
                    }
                    catch { }
                }
            }
    
            public static string GetString(string key)
            {
                string value = "";
    
                try
                {
                    string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToLower();
    
                    if (string.IsNullOrEmpty(language))
                    {
                        language = DEFAULT_LANGUAGE_VALUE;
                    }
    
                    if (ResourceSets.ContainsKey(language))
                    {
                        value = ResourceSets[language].GetString(key);
                    }
    
                }
                catch { }
    
                return value ?? "";
            }
