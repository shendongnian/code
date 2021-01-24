    class Store
    {
    private:
    	int value;
    
    public:
    	__declspec(dllexport) void Put(int value)
    	{
    		this->value = value;
    	}
    
    	__declspec(dllexport) int Get()
    	{
    		return this->value;
    	}
    
    	__declspec(dllexport) void Increment()
    	{
    		this->value++;
    	}
    };
    
    extern "C"
    {
    	__declspec(dllexport) int PlusOne(int x)
    	{
    		return x + 1;
    	}
    
    	__declspec(dllexport) Store* NewStore()
    	{
    		return new Store;
    	}
    
    	__declspec(dllexport) void DeleteStore(Store* store)
    	{
    		delete store;
    	}
    }
    class Program
    {
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int PlusOne(int x);
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr NewStore();
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void DeleteStore(IntPtr store);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Put@Store@@QAEXH@Z")]
        extern static void Put32(IntPtr store, int value);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Get@Store@@QAEHXZ")]
        extern static int Get32(IntPtr store);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Increment@Store@@QAEXXZ")]
        extern static void Increment32(IntPtr store);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Put@Store@@QEAAXH@Z")]
        extern static void Put64(IntPtr store, int value);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Get@Store@@QEAAHXZ")]
        extern static int Get64(IntPtr store);
        // EntryPoint generated with DUMPBIN /exports dllname.dll
        [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Increment@Store@@QEAAXXZ")]
        extern static void Increment64(IntPtr store);
        static void Main(string[] args)
        {
            int x = PlusOne(1);
            Console.WriteLine(x);
            IntPtr store = NewStore();
            int ret;
            if (IntPtr.Size == 8)
            {
                Put64(store, 5);
                Increment64(store);
                ret = Get64(store);
            }
            else
            {
                Put32(store, 5);
                Increment32(store);
                ret = Get32(store);
            }
            Console.WriteLine(ret);
            DeleteStore(store);
        }
    }
