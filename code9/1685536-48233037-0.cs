        class MysticLight
        {
            public const string sMysticLightDll = "C:\\GitHub\\UniversalRGB\\Universal RGB Sync\\MysticLight_SDK.dll";
            [DllImport(sMysticLightDll, CharSet = CharSet.Unicode, EntryPoint = "MLAPI_Initialize")]
            public static extern int MLAPI_Initialize_();
            [DllImport(sMysticLightDll, CharSet = CharSet.Unicode, EntryPoint = "MLAPI_SetLedColor")]
            public static extern Int16 MLAPI_SetLedColor_(IntPtr bstr, Uint32 index, UInt32 R, UInt32 G, UInt32 B);
            Int16 SetLedColor(string text,UInt32 index, UInt32 R, UInt32 G, UInt32 B)
            {
                IntPtr textPtr = Marshal.StringToHGlobalUni(text);
                Int16 status = MLAPI_SetLedColor_(textPtr, index, R, G, B);
                return status;
            }
        }
