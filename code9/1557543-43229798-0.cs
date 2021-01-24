            [DllImport("bin32\\Native86Dll", EntryPoint = "MyFunc", CharSet = CharSet.Ansi, ExactSpelling = true)]
            public static extern int MyFunc_32(string sCommand);
    
            [DllImport("bin64\\Native64Dll", EntryPoint = "MyFunc", CharSet = CharSet.Ansi, ExactSpelling = true)]
            public static extern int MyFunc_64(string sCommand);
    
            public static int MyFunc(string sCommand )
            {
                return System.Environment.Is64BitProcess ? MyFunc_64(sCommand) : MyFunc_32(sCommand);
            }
