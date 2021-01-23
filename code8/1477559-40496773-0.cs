    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct MyStruct {
        
        /// OtherStruct1*
        public System.IntPtr data1;
        
        /// OtherStruct2*
        public System.IntPtr data2;
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct OtherStruct1 {
        
        /// double
        public double x;
        
        /// char
        public byte y;
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct OtherStruct2 {
        
        /// float
        public float a;
        
        /// float
        public float b;
        
        /// float
        public float c;
        
        /// float
        public float d;
    }
    
    public partial class NativeMethods {
        
        /// Return Type: MyStruct*
        [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetPointer")]
    public static extern  System.IntPtr GetPointer() ;
    
    }
