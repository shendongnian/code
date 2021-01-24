        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern ITypeLib LoadTypeLib([In, MarshalAs(UnmanagedType.LPWStr)] string typelib);
        public static void ParseTypeLib(string filePath)
        {
            string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            ITypeLib typeLib = LoadTypeLib(filePath);
            int count = typeLib.GetTypeInfoCount();
            IntPtr ipLibAtt = IntPtr.Zero;
            typeLib.GetLibAttr(out ipLibAtt);
            var typeLibAttr = (System.Runtime.InteropServices.ComTypes.TYPELIBATTR)
                Marshal.PtrToStructure(ipLibAtt, typeof(System.Runtime.InteropServices.ComTypes.TYPELIBATTR));
            Guid tlbId = typeLibAttr.guid;
            for(int i=0; i< count; i++)
            {
                ITypeInfo typeInfo = null;
                typeLib.GetTypeInfo(i, out typeInfo);
                //figure out what guids, typekind, and names of the thing we're dealing with
                IntPtr ipTypeAttr = IntPtr.Zero;
                typeInfo.GetTypeAttr(out ipTypeAttr);
                
                //unmarshal the pointer into a structure into something we can read
                var typeattr = (System.Runtime.InteropServices.ComTypes.TYPEATTR)
                    Marshal.PtrToStructure(ipTypeAttr, typeof(System.Runtime.InteropServices.ComTypes.TYPEATTR));
                System.Runtime.InteropServices.ComTypes.TYPEKIND typeKind = typeattr.typekind;
                Guid typeId = typeattr.guid;
            
                //get the name of the type
                string strName, strDocString, strHelpFile;
                int dwHelpContext;
                typeLib.GetDocumentation(i, out strName, out strDocString, out dwHelpContext, out strHelpFile);
                
                if (typeKind == System.Runtime.InteropServices.ComTypes.TYPEKIND.TKIND_COCLASS)
                {
                    string xmlComClassFormat = "<comClass clsid=\"{0}\" tlbid=\"{1}\" description=\"{2}\" progid=\"{3}.{4}\"></comClass>";
                    string comClassXml = String.Format(xmlComClassFormat, 
                        typeId.ToString("B").ToUpper(),
                        tlbId.ToString("B").ToUpper(),
                        strDocString,
                        fileNameOnly, strName
                        );
                    //Debug.WriteLine(comClassXml);
                }
                else if(typeKind == System.Runtime.InteropServices.ComTypes.TYPEKIND.TKIND_INTERFACE)
                {
                    string xmlProxyStubFormat = "<comInterfaceExternalProxyStub name=\"{0}\" iid=\"{1}\" tlbid=\"{2}\" proxyStubClsid32=\"{3}\"></comInterfaceExternalProxyStub>";
                    string proxyStubXml = String.Format(xmlProxyStubFormat,
                        strName,
                        typeId.ToString("B").ToUpper(),
                        tlbId.ToString("B").ToUpper(),
                        "{00020424-0000-0000-C000-000000000046}"
                    );
                    //Debug.WriteLine(proxyStubXml);
                }
                
            }
            return;
        }
    }
