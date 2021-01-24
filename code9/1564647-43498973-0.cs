    using System.Runtime.InteropServices;
    public class Ole32
    {
      [DllImport("Ole32.Dll")]
      public static extern int CreateBindCtx(int reserved,
      out UCOMIBindCtx bindCtx);
      [DllImport("oleaut32.dll")]
      public static extern int RegisterActiveObject
          ([MarshalAs(UnmanagedType.IUnknown)] object punk,
              ref Guid rclsid, uint dwFlags, out int pdwRegister);
      // End of Ole32 class definition
    }
