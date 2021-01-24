      [ComVisible(true)]
    
       [Guid("12345678-3914-41F0-BB26-122986A93788")]
    
       [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    
       public interface IMat
       {...}
    
       public class ManagedMat : IMat
       {...}
      [DllImport("cppProjectname.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
      public static extern int call2Cpp(IMat obj);
