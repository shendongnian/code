    public static class Utilities
    {
        /// <summary>
        /// Build File Into Assembly
        /// </summary>
        /// <param name="sourceName"></param>
        /// <returns>https://msdn.microsoft.com/en-us/library/microsoft.csharp.csharpcodeprovider.aspx</returns>
        public static Assembly BuildFileIntoAssembly(String fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException($"File '{fileName}' does not exist");
            // Select the code provider based on the input file extension
            FileInfo sourceFile = new FileInfo(fileName);
            string providerName = sourceFile.Extension.ToUpper() == ".CS" ? "CSharp" :
                                  sourceFile.Extension.ToUpper() == ".VB" ? "VisualBasic" : "";
            if (providerName == "")
                throw new ArgumentException("Source file must have a .cs or .vb extension");
            CodeDomProvider provider = CodeDomProvider.CreateProvider(providerName);
            CompilerParameters cp = new CompilerParameters();
            // just add every currently loaded assembly:
            // https://stackoverflow.com/a/1020547/1366033
            var assemblies = from asm in AppDomain.CurrentDomain.GetAssemblies()
                             where !asm.IsDynamic
                             select asm.Location;
            cp.ReferencedAssemblies.AddRange(assemblies.ToArray());
            cp.GenerateExecutable = false; // Generate a class library
            cp.GenerateInMemory = true; // Don't Save the assembly as a physical file.
            cp.TreatWarningsAsErrors = false; // Set whether to treat all warnings as errors.
            // Invoke compilation of the source file.
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, fileName);
            if (cr.Errors.Count > 0)
                throw new Exception("Errors compiling {0}. " +
                    string.Join(";", cr.Errors.Cast<CompilerError>().Select(x => x.ToString())));
            
            return cr.CompiledAssembly;
        }
        // have to use FullName not full equality because different classes that look the same
        public static object GetTypeFromAssembly(Assembly asm, String typeName)
        {
            var inst = from type in asm.GetTypes()
                       where type.FullName == typeName
                       select Activator.CreateInstance(type);
            return inst.First();
        }
        /// <summary>
        /// Extension for 'Object' that copies the properties to a destination object.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="target">The target</param>
        /// <remarks>
        /// https://stackoverflow.com/q/930433/1366033
        /// </remarks>
        public static T2 CopyProperties<T1, T2>(T1 source, T2 target)
        {
            // If any this null throw an exception
            if (source == null || target == null)
                throw new ArgumentNullException("Source or/and Destination Objects are null");
            // Getting the Types of the objects
            Type typeTar = target.GetType();
            Type typeSrc = source.GetType();
            // Collect all the valid properties to map
            var results = from srcProp in typeSrc.GetProperties()
                          let targetProperty = typeTar.GetProperty(srcProp.Name)
                          where srcProp.CanRead
                             && targetProperty != null
                             && (targetProperty.GetSetMethod(true) != null && !targetProperty.GetSetMethod(true).IsPrivate)
                             && (targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) == 0
                             && targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType)
                          select (sourceProperty: srcProp, targetProperty: targetProperty);
            //map the properties
            foreach (var props in results)
            {
                props.targetProperty.SetValue(target, props.sourceProperty.GetValue(source, null), null);
            }
            return target;
        }
    }
