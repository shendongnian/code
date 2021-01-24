    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
            bool toUnicodeIsTrue=false;
            char t = GetCharFromKey(e.Key, ref toUnicodeIsTrue);
            if ( t == '/')
            {
                // do stuff
            }
            base.OnPreviewKeyDown(e);  
    }
        public static char GetCharFromKey(System.Windows.Input.Key key, ref bool toUnicodeIsTrue)
        {
            toUnicodeIsTrue = true;
            char ch = ' ';
            // First, you need to get the VirtualKey code. Thankfully, there’s a simple class 
            // called KeyInterop, which exposes a static method VirtualKeyFromKey 
            // that gets us this information
            int virtualKey = System.Windows.Input.KeyInterop.VirtualKeyFromKey(key);
            //Then, we need to get the character. This is much trickier. 
            //First we have to get the keyboard state and then we have to map that VirtualKey 
            //we got in the first step to a ScanCode, and finally, convert all of that to Unicode, 
            //because .Net doesn’t really speak ASCII
            byte[] keyboardState = new byte[256];
            GetKeyboardState(keyboardState);
            uint scanCode = MapVirtualKey((uint)virtualKey, MapType.MAPVK_VK_TO_VSC);
            StringBuilder stringBuilder = new StringBuilder(2);
            int result = ToUnicode((uint)virtualKey, scanCode, keyboardState, stringBuilder, stringBuilder.Capacity, 0);
            switch (result)
            {
                case -1:
                    toUnicodeIsTrue = false;
                    break;
                case 0:
                    toUnicodeIsTrue = false;
                    break;
                case 1:
                    {
                        ch = stringBuilder[0];
                        break;
                    }
                default:
                    {
                        ch = stringBuilder[0];
                        break;
                    }
            }
            return ch;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, MapType uMapType);
        public enum MapType : uint
        {
            MAPVK_VK_TO_VSC = 0x0,
            MAPVK_VSC_TO_VK = 0x1,
            MAPVK_VK_TO_CHAR = 0x2,
            MAPVK_VSC_TO_VK_EX = 0x3,
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ToUnicode(
            uint wVirtKey,
            uint wScanCode,
            byte[] lpKeyState,
            [System.Runtime.InteropServices.Out, System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr, SizeParamIndex = 4)]
            StringBuilder pwszBuff,
            int cchBuff,
            uint wFlags);
    }
