    public static class CosturaAssemblyExtractor
    {
        public static Dictionary<string, Assembly> Extract(AppDomain OrigDomain, Assembly ExecutingAssembly, string AssemblyStartsWith)
        {
            //var currentDomain = origDomain;
            var assemblies = OrigDomain.GetAssemblies();
            var references = new Dictionary<string, Assembly>();
            var manifestResourceNames = ExecutingAssembly.GetManifestResourceNames().Where(x => {
                return x.ToUpper().StartsWith(("costura." + AssemblyStartsWith).ToUpper()) && x.ToUpper().EndsWith(".dll.zip".ToUpper());
            });
            foreach (var resourceName in manifestResourceNames)
            {
                var solved = false;
                foreach (var assembly in assemblies)
                {
                    var refName = string.Format("costura.{0}.dll.zip", GetDllName(assembly, true));
                    if (resourceName.Equals(refName, StringComparison.OrdinalIgnoreCase))
                    {
                        references[assembly.FullName] = assembly;
                        solved = true;
                        break;
                    }
                }
                if (solved)
                    continue;
                using (var resourceStream = ExecutingAssembly.GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null) continue;
                    if (resourceName.EndsWith(".dll.zip"))
                    {
                        using (var compressStream = new DeflateStream(resourceStream, CompressionMode.Decompress))
                        {
                            var memStream = new MemoryStream();
                            CopyTo(compressStream, memStream);
                            memStream.Position = 0;
                            var rawAssembly = new byte[memStream.Length];
                            memStream.Read(rawAssembly, 0, rawAssembly.Length);
                            var reference = Assembly.Load(rawAssembly);
                            references[reference.FullName] = reference;
                        }
                    }
                    else
                    {
                        var rawAssembly = new byte[resourceStream.Length];
                        resourceStream.Read(rawAssembly, 0, rawAssembly.Length);
                        var reference = Assembly.Load(rawAssembly);
                        references[reference.FullName] = reference;
                    }
                }
            }
            return references;
        }
        private static void CopyTo(Stream source, Stream destination)
        {
            var array = new byte[81920];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
            {
                destination.Write(array, 0, count);
            }
        }
        private static string GetDllName(Assembly assembly, bool withoutExtension = false)
        {
            var assemblyPath = assembly.CodeBase;
            return withoutExtension ? Path.GetFileNameWithoutExtension(assemblyPath) : Path.GetFileName(assemblyPath);
        }
    }
