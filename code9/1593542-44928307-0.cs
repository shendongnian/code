        internal static Assembly LoadAssemblyFromString(String assemblyName) {
            //
            // Try using the stringized assembly name to load from the fusion cache.
            //
            BCLDebug.Trace("SER", "[LoadAssemblyFromString]Looking for assembly: ", assemblyName);
            Assembly found = Assembly.Load(assemblyName);
            return found;
        }
