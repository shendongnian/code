    // Step 1: For Load On-Screen Keyboard
        const string Kernel32dll = "Kernel32.Dll";
        [DllImport(Kernel32dll, EntryPoint = "Wow64DisableWow64FsRedirection")]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport(Kernel32dll, EntryPoint = "Wow64EnableWow64FsRedirection")]
        public static extern bool Wow64EnableWow64FsRedirection(IntPtr ptr);
        IntPtr wow64Value;
        //---------------------------------------
       // Step 2: Function-----
       if (Environment.Is64BitOperatingSystem)
                {
                    if (Wow64DisableWow64FsRedirection(ref wow64Value))
                    {
                        System.Diagnostics.Process.Start("osk.exe");
                        Wow64EnableWow64FsRedirection(wow64Value);
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start("osk.exe");
                }
       //----------------
