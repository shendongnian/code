    // StandardOleMarshalObject keeps us single-threaded on the UI thread
    // https://msdn.microsoft.com/en-us/library/74169f59(v=vs.110).aspx
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId(IpcConstants.CoordinatorProgID)]
    public sealed class Coordinator : StandardOleMarshalObject, ICoordinator
    {
        public Coordinator()
        {
            // required for regasm
        }
        #region Registration
        [ComRegisterFunction]
        internal static void RegasmRegisterLocalServer(string path)
        {
            // path is HKEY_CLASSES_ROOT\\CLSID\\{clsid}", we only want CLSID...
            path = path.Substring("HKEY_CLASSES_ROOT\\".Length);
            using (RegistryKey keyCLSID = Registry.ClassesRoot.OpenSubKey(path, writable: true))
            {
                // Remove the auto-generated InprocServer32 key after registration
                // (REGASM puts it there but we are going out-of-proc).
                keyCLSID.DeleteSubKeyTree("InprocServer32");
                // Create "LocalServer32" under the CLSID key
                using (RegistryKey subkey = keyCLSID.CreateSubKey("LocalServer32"))
                {
                    subkey.SetValue("", Assembly.GetExecutingAssembly().Location, RegistryValueKind.String);
                }
            }
        }
        [ComUnregisterFunction]
        internal static void RegasmUnregisterLocalServer(string path)
        {
            // path is HKEY_CLASSES_ROOT\\CLSID\\{clsid}", we only want CLSID...
            path = path.Substring("HKEY_CLASSES_ROOT\\".Length);
            Registry.ClassesRoot.DeleteSubKeyTree(path, throwOnMissingSubKey: false);
        }
        #endregion
    }
