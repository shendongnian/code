    using System;
    using System.Runtime.InteropServices;
    
    namespace TestApp {
        static class Wincrypt {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct CRYPTOAPI_BLOB {
                public UInt32 cbData;
                public IntPtr pbData;
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]    
            public struct CERT_EXTENSION {
                [MarshalAs(UnmanagedType.LPStr)]
                public String pszObjId;
                public Boolean fCritical;
                public CRYPTOAPI_BLOB Value;
            }
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct CERT_EXTENSIONS {
                public UInt32 cExtension;
                public IntPtr rgExtension;
            }
    		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    		public struct CERT_ALT_NAME_INFO {
    			public UInt32 cAltEntry;
    			public IntPtr rgAltEntry;
    		}
    		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct CERT_ALT_NAME_ENTRY {
                public UInt32 dwAltNameChoice;
    			// since there is no direct translation from C-like unions in C#
    			// make additional struct to represent union options.
    			public CERT_ALT_NAME_UNION Value;
    		}
    		// create mapping to dwAltNameChoice
    		public const UInt32 CERT_ALT_NAME_OTHER_NAME = 1;
    		public const UInt32 CERT_ALT_NAME_RFC822_NAME = 2;
    		public const UInt32 CERT_ALT_NAME_DNS_NAME = 3;
    		public const UInt32 CERT_ALT_NAME_X400_ADDRESS = 4;
    		public const UInt32 CERT_ALT_NAME_DIRECTORY_NAME = 5;
    		public const UInt32 CERT_ALT_NAME_EDI_PARTY_NAME = 6;
    		public const UInt32 CERT_ALT_NAME_URL = 7;
    		public const UInt32 CERT_ALT_NAME_IP_ADDRESS = 8;
    		public const UInt32 CERT_ALT_NAME_REGISTERED_ID = 9;
    
    		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
            public struct CERT_ALT_NAME_UNION {
                [FieldOffset(0)]
                public IntPtr pOtherName;
                [FieldOffset(0)]
                public IntPtr pwszRfc822Name;
                [FieldOffset(0)]
                public IntPtr pwszDNSName;
                [FieldOffset(0)]
                public CRYPTOAPI_BLOB DirectoryName;
                [FieldOffset(0)]
                public IntPtr pwszURL;
                [FieldOffset(0)]
                public IntPtr IPAddress;
                [FieldOffset(0)]
                public IntPtr pszRegisteredID;
            }
            // not really used in this scenario, but is necessary when want to add
            // UPN alt name, for example.
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct CERT_OTHER_NAME {
                [MarshalAs(UnmanagedType.LPStr)]
                public String pszObjId;
                public CRYPTOAPI_BLOB Value;
            }
        }
    }
