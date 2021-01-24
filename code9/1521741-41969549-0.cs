        private static Tuple<Assembly, string> FindEmbeddedResource(string name, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(r => r.EndsWith(name));
                if (resourceName != null)
                {
                    return new Tuple<Assembly, string>(assembly, resourceName);
                }
            }
            return new Tuple<Assembly, string>(null, null);
        }
        /// <summary>
        /// Gets the embedded resource scanning assemblies in the order supplied. Allows APIs to override library assets.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns></returns>
        private static string GetEmbeddedResource(string name, params Assembly[] assemblies)
        {
            var embeddedResource = FindEmbeddedResource(name, assemblies);
            var assembly = embeddedResource.Item1;
            var resource = embeddedResource.Item2;
            if (assembly != null)
            {
                var stream = assembly.GetManifestResourceStream(resource);
                using (var textStreamReader = new StreamReader(stream))
                {
                    resource = textStreamReader.ReadToEnd();
                }
            }
            return resource;
        }
