            [DllImport("ole32.dll")]
            public static extern int CoInitializeSecurity(IntPtr pVoid, int
                cAuthSvc, IntPtr asAuthSvc, IntPtr pReserved1, RPCAUTHNLEVEL level,
                RPCIMPLEVEL impers, IntPtr pAuthList, EOAUTHNCAP dwCapabilities, IntPtr
                pReserved3);
    
            public enum RPCAUTHNLEVEL
            {
                Default = 0,
                None = 1,
                Connect = 2,
                Call = 3,
                Pkt = 4,
                PktIntegrity = 5,
                PktPrivacy = 6
            }
    
            public enum RPCIMPLEVEL
            {
                Default = 0,
                Anonymous = 1,
                Identify = 2,
                Impersonate = 3,
                Delegate = 4
            }
    
            public enum EOAUTHNCAP
            {
                None = 0x00,
                MutualAuth = 0x01,
                StaticCloaking = 0x20,
                DynamicCloaking = 0x40,
                AnyAuthority = 0x80,
                MakeFullSIC = 0x100,
                Default = 0x800,
                SecureRefs = 0x02,
                AccessControl = 0x04,
                AppID = 0x08,
                Dynamic = 0x10,
                RequireFullSIC = 0x200,
                AutoImpersonate = 0x400,
                NoCustomMarshal = 0x2000,
                DisableAAA = 0x1000
            }
