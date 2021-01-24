        private IVsBuildPropertyStorage GetBuildPropertyStorage(EnvDTE.Project project)
        {
            IVsSolution solution = (IVsSolution)ServiceProvider.GetService(typeof(SVsSolution));
            IVsHierarchy hierarchy;
            int hr = solution.GetProjectOfUniqueName(project.FullName, out hierarchy);
            System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(hr);
            return hierarchy as IVsBuildPropertyStorage;
        }
        private string GetBuildProperty(string key, IVsBuildPropertyStorage Storage)
        {
            string value;
            int hr = Storage.GetPropertyValue(key, null, (uint)_PersistStorageType.PST_USER_FILE, out value);
            int E_XML_ATTRIBUTE_NOT_FOUND = unchecked((int)0x8004C738);
            // ignore this HR, it means that there's no value for this key
            if (hr != E_XML_ATTRIBUTE_NOT_FOUND)
            {
                System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(hr);
            
            }
            return value;
        }
