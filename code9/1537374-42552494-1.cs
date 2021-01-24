    class Program
    {
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int PlusOne(int x);
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr NewStore();
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void DeleteStore(IntPtr store);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Put@Store@@QEAAXH@Z")]
        extern static void Put(IntPtr store, int value);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Get@Store@@QEAAHXZ")]
        extern static int Get(IntPtr store);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Increment@Store@@QEAAXXZ")]
        extern static void Increment(IntPtr store);
        static void Main(string[] args)
        {
            int x = PlusOne(1);
            Console.WriteLine(x);
            IntPtr store = NewStore();
            Put(store, 5);
            Increment(store);
            int ret = Get(store);
            Console.WriteLine(ret);
            DeleteStore(store);
        }
    }
