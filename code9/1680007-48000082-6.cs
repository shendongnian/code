    using System;
    using System.Runtime.InteropServices;
    using Accessibility;
    
    namespace Test
    {
    class TestApp 
    {
    
    
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr FindWindow(string lpClassName, IntPtr zero);
    
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("oleacc.dll", ExactSpelling = true, PreserveSig = false)]
    [return: MarshalAs(UnmanagedType.Interface)]
    static extern object AccessibleObjectFromWindow(IntPtr hwnd, uint dwObjectID, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
    
    static Guid IID_IAccessible = new Guid("{618736E0-3C3D-11CF-810C-00AA00389B71}");
    
    enum OBJID : uint { WINDOW = 0x00000000, SYSMENU = 0xFFFFFFFF, TITLEBAR = 0xFFFFFFFE, MENU = 0xFFFFFFFD, CLIENT = 0xFFFFFFFC, }
    
    
    static void Main() 
    {
    	IntPtr hCalc = FindWindow("CalcFrame", IntPtr.Zero);
    	Console.WriteLine("Calc HWND is "+hCalc);
        if (hCalc == IntPtr.Zero) return ;
    	try
    	{
    		IAccessible acc = (IAccessible) AccessibleObjectFromWindow(hCalc, (uint)OBJID.CLIENT, IID_IAccessible);
    		int x, y, w, h;
    		acc.accLocation(out x, out y, out w, out h, null);
    		Console.WriteLine(string.Format("pos: {0}x{1} size:{2}x{3}", x, y, w, h));
    	}
    	catch (System.Runtime.InteropServices.COMException)
    	{
    	}
    }
    }
    }
