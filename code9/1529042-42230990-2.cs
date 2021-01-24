    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("OriginalCPPDll.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Wrap_Create();
            [DllImport("OriginalCPPDll.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Wrap_Destroy(IntPtr pObj);
            [DllImport("OriginalCPPDll.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 Wrap_DoTheWork(IntPtr pObj, byte[] dest, byte[] src, Int32 szSrc);
            static void Main(string[] args)
            {
                string srcStr = "this is the source string";
                
                byte[] resBytes = new byte[srcStr.Length*2];
                byte[] srcBytes = Encoding.ASCII.GetBytes(srcStr);
                Int32 srcSize = srcBytes.Length;
                
                IntPtr obj = Wrap_Create();
                
                Int32 size = Wrap_DoTheWork(obj, resBytes, srcBytes, srcSize);
                Wrap_Destroy(obj);
            }
        }
    }
