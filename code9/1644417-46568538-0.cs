    using System;
    using System.Runtime.InteropServices;
    namespace PowrprofTest {
        class Program {
            private static readonly Guid CONSOLELOCK = new Guid("0e796bdb-100d-47d6-a2d5-f7d2daa51f51");
            private static readonly Guid SUB_NONE = new Guid("fea3413e-7e05-4911-9a71-700331f1c294");
            [StructLayout(LayoutKind.Sequential)]
            public class GuidClass {
                public Guid Value;
            }
            [DllImport("powrprof.dll")]
            public static extern UInt32 PowerGetActiveScheme(
                IntPtr UserRootPowerKey,
                ref IntPtr ActivePolicyGuid
            );
            [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerReadACValueIndex(
                IntPtr RootPowerKey,
                ref Guid SchemeGuid,
                ref Guid SubGroupOfPowerSettingsGuid,
                ref Guid PowerSettingGuid,
                ref UInt32 AcValueIndex
            );
            [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerReadDCValueIndex(
                IntPtr RootPowerKey, ref Guid SchemeGuid,
                ref Guid SubGroupOfPowerSettingsGuid,
                ref Guid PowerSettingGuid,
                ref UInt32 AcValueIndex
            );
            static void Main(string[] args) {
                Guid scheme = GetActiveSchemeGuid();
                bool sleepLockEnabledAC = (GetACValue(scheme, SUB_NONE, CONSOLELOCK) == 1) ? true: false;
                bool sleepLockEnabledDC = (GetDCValue(scheme, SUB_NONE, CONSOLELOCK) == 1) ? true : false;
            
                Console.WriteLine("Sleep lock enabled on AC : " + sleepLockEnabledAC);
                Console.WriteLine("Sleep lock enabled on DC : " + sleepLockEnabledDC);
                Console.ReadLine();
            }
            static Guid GetActiveSchemeGuid() {
                IntPtr activeSchemePtr = IntPtr.Zero;
                uint res = PowerGetActiveScheme(IntPtr.Zero, ref activeSchemePtr);
                GuidClass temp = new GuidClass();
                Marshal.PtrToStructure(activeSchemePtr, temp);
                Guid scheme = temp.Value;
                return scheme;
            }      
            /// <summary>
            /// Get setting for Plugged in
            /// </summary>
            static UInt32 GetACValue(Guid scheme, Guid subgroup, Guid setting) {
                UInt32 value = 0;
                PowerReadACValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, ref value);
                return value;
            }
            /// <summary>
            /// Get setting for On battery
            /// </summary>
            static UInt32 GetDCValue(Guid scheme, Guid subgroup, Guid setting) {
                UInt32 value = 0;
                PowerReadDCValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, ref value);
                return value;
            }
        }
    }
