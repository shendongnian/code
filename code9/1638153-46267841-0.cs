    using System;
    using System.Runtime.InteropServices;
    namespace ExceptionInCatch
    {
        class Program
        {
            [DllImport("wer.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern int WerAddExcludedApplication(String pwzExeName, bool bAllUsers);
    
            [Flags]
            public enum ErrorModes : uint
            {
                SYSTEM_DEFAULT = 0x0,
                SEM_FAILCRITICALERRORS = 0x0001,
                SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,
                SEM_NOGPFAULTERRORBOX = 0x0002,
                SEM_NOOPENFILEERRORBOX = 0x8000,
                SEM_NONE = SEM_FAILCRITICALERRORS | SEM_NOALIGNMENTFAULTEXCEPT | SEM_NOGPFAULTERRORBOX | SEM_NOOPENFILEERRORBOX
            }
    
            [DllImport("kernel32.dll")]
            static extern ErrorModes SetErrorMode(ErrorModes uMode);
    
    
            public static void Main(string[] args)
            {
                var executableName = AppDomain.CurrentDomain.FriendlyName;
                WerAddExcludedApplication(executableName, false);
                SetErrorMode(ErrorModes.SEM_NONE);
                try
                {
                    throw new Exception("Apple");
                }
                catch (Exception ex)
                {
                    throw new Exception("Banana");
                }
                finally
                {
                    // This line will now execute
                    Console.WriteLine("Carrot");
                }
            }
        }
    }
