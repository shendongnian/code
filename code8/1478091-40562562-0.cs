    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            var obj = new WUApiLib.UpdateInstaller();
            var punk = Marshal.GetIUnknownForObject(obj);
            var iid4 = new Guid("EF8208EA-2304-492D-9109-23813B0958E1");
            IntPtr itf4;
            var hr = Marshal.QueryInterface(punk, ref iid4, out itf4);
            Debug.Assert(hr == 0 && itf4 != IntPtr.Zero);  // fine
        }
    }
