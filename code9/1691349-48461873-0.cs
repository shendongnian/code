    class Program
    {
        [STAThread] // don't forget STAThread, most shell methods require that
        static void Main(string[] args)
        {
            string path = @"d:\kilroy_was_here\test.htm";
            int hr = SHCreateItemFromParsingName(path, null, typeof(IShellItem).GUID, out IShellItem item);
            if (hr != 0)
                throw new Win32Exception(hr);
            hr = SHAssocEnumHandlers(Path.GetExtension(path), ASSOC_FILTER.ASSOC_FILTER_RECOMMENDED, out IEnumAssocHandlers eah);
            if (hr != 0)
                throw new Win32Exception(hr);
            do
            {
                eah.Next(1, out IAssocHandler handler, out int fetched);
                if (fetched != 1)
                    break;
                handler.GetName(out string name);
                Console.WriteLine(name);
                if (name.Contains("firefox")) // open with firefox, for example
                {
                    var BHID_DataObject = new Guid("b8c0bd9f-ed24-455c-83e6-d5390c4fe8c4");
                    var dao = item.BindToHandler(null, BHID_DataObject, typeof(IDataObject).GUID);
                    handler.Invoke(dao);
                }
            }
            while (true);
        }
        [Flags]
        public enum ASSOC_FILTER
        {
            ASSOC_FILTER_NONE = 0x00000000,
            ASSOC_FILTER_RECOMMENDED = 0x00000001
        }
        [Guid("973810ae-9599-4b88-9e4d-6ee98c9552da"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IEnumAssocHandlers
        {
            [PreserveSig]
            int Next(int celt, out IAssocHandler rgelt, out int pceltFetched);
        }
        [Guid("f04061ac-1659-4a3f-a954-775aa57fc083"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IAssocHandler
        {
            void GetName([MarshalAs(UnmanagedType.LPWStr)] out string ppsz);
            void GetUIName([MarshalAs(UnmanagedType.LPWStr)] out string ppsz);
            void GetIconLocation([MarshalAs(UnmanagedType.LPWStr)] out string ppszPath, out int pIndex);
            [PreserveSig]
            int IsRecommended();
            void MakeDefault([MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
            void Invoke(IDataObject pdo);
            void CreateInvoker(IDataObject pdo, out /*IAssocHandlerInvoker*/ object invoker);
        }
        [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellItem
        {
            // here we only need this member
            IDataObject BindToHandler(IBindCtx pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);
        }
        [DllImport("shell32", CharSet = CharSet.Unicode)]
        private extern static int SHCreateItemFromParsingName(string pszPath, IBindCtx pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItem ppv);
        [DllImport("shell32", CharSet = CharSet.Unicode)]
        private extern static int SHAssocEnumHandlers(string pszExtra, ASSOC_FILTER afFilter, out IEnumAssocHandlers ppEnumHandler);
    }
