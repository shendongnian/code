    using System;
    using System.Runtime.InteropServices;
    
    namespace AssocHandlerWithPointer
    {
      [Flags]
      public enum ASSOC_FILTER
      {
        ASSOC_FILTER_NONE = 0x00000000,
        ASSOC_FILTER_RECOMMENDED = 0x00000001
      }
    
      public class Test
      {
        [DllImport("Shell32", EntryPoint = "SHAssocEnumHandlers", PreserveSig = false)]
        public extern static void SHAssocEnumHandlers([MarshalAs(UnmanagedType.LPWStr)] string pszExtra, ASSOC_FILTER afFilter, [Out] out IntPtr ppEnumHandler);
    
        // IEnumAssocHandlers
        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private delegate int FuncNext(IntPtr refer, int celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IntPtr[] rgelt, [Out] out int pceltFetched);
    
        // IAssocHandler
        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private delegate int FuncGetName(IntPtr refer, out IntPtr ppsz);
    
        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        private delegate int FuncGetUiName(IntPtr refer, out IntPtr ppsz);  
    
       
        static void Main(string[] args)
        {
          const string extension = ".html";
    
          IntPtr pEnumAssocHandlers;
          SHAssocEnumHandlers(extension, ASSOC_FILTER.ASSOC_FILTER_RECOMMENDED, out pEnumAssocHandlers);
    
          IntPtr pFuncNext = Marshal.ReadIntPtr(Marshal.ReadIntPtr(pEnumAssocHandlers) + 3 * sizeof(int));
          FuncNext next = (FuncNext)Marshal.GetDelegateForFunctionPointer(pFuncNext, typeof(FuncNext));
    
          IntPtr[] pArrayAssocHandlers  = new IntPtr[255];
          int num;
    
          int resNext = next(pEnumAssocHandlers, 255, pArrayAssocHandlers, out num);
          if (resNext == 0)
          {
            for (int i = 0; i < num; i++)
            {
              IntPtr pAssocHandler = pArrayAssocHandlers[i];
              IntPtr pFuncGetName = Marshal.ReadIntPtr(Marshal.ReadIntPtr(pAssocHandler) + 3 * sizeof(int));
              FuncGetName getName = (FuncGetName)Marshal.GetDelegateForFunctionPointer(pFuncGetName, typeof(FuncGetName));
              IntPtr pName;
              int resGetName = getName(pAssocHandler, out pName);
              Console.WriteLine("Path: " + Marshal.PtrToStringUni(pName));
    
              IntPtr pFuncGetUiName = Marshal.ReadIntPtr(Marshal.ReadIntPtr(pAssocHandler) + 4 * sizeof(int));
              FuncGetUiName getUiName = (FuncGetUiName)Marshal.GetDelegateForFunctionPointer(pFuncGetUiName, typeof(FuncGetUiName));
              IntPtr pUiName;
              int resGetUiName = getUiName(pAssocHandler, out pUiName);
              Console.WriteLine("UIName: " + Marshal.PtrToStringUni(pUiName));
             
              Marshal.Release(pArrayAssocHandlers[i]);
            }
          }
          Marshal.Release(pEnumAssocHandlers);
          Console.ReadLine();
        }
      }
    }
