      public static class ResourceWrapper
        {
            private static Dictionary<string, ResourceSet> _resourceSets = new Dictionary<string, ResourceSet>();
            static ResourceWrapper()
            {
                _resourceSets.Add("uk", Load("uk"));
                _resourceSets.Add("ru", Load("ru"));
                _resourceSets.Add("en", Emails.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, false, false));
            }
    
            private static ResourceSet Load(string lang)
            {
                var asm = System.Reflection.Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, "bin", lang, "Function.App.resources.dll"));
                 var resourceName = $"Function.App.Resources.Emails.{lang}.resources";
                 var tt = asm.GetManifestResourceNames();
                return new ResourceSet(asm.GetManifestResourceStream(resourceName));
            }
    
            public static string GetString(string key)
            {
                return _resourceSets[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName].GetString(key);
            }
        }
