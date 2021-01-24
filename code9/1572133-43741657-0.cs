    using System;
    using System.Runtime.InteropServices;
    static void Main()
    {
        EnumWindows(E, IntPtr.Zero);
        Console.Write($"{_.Item1}x{_.Item2}");
    }
    
    
    struct R
    {
        int l;
        int t;
        public int r;
        public int b;
    
        public override string ToString() => $"{l},{t},{r},{b}";
        public bool i() => l == 0 && r != 00;
    }
    
    static (int, int) _;
    
    static bool E(IntPtr w, IntPtr l)
    {
        var r = new R();
        GetWindowRect(w, ref r);
        if (r.i() && _.Item1 == 0)
            _ = (r.r, r.b);
        return true;
    }
    
    delegate bool P(IntPtr w, IntPtr l);
    
    [DllImport("user32.dll")]
    static extern bool EnumWindows(P e, IntPtr l);
    
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr w, ref R r);
    Main()
