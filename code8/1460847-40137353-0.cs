    public static class Class1
    {
        static Class1()
        {
            Console.WriteLine("DLL MAIN (Only DLL_PROCESS_ATTACH) :D");
        }
        [DllExport("AddFunc", CallingConvention.Cdecl)]
        public static int AddFunc(int a, int b)
        {
            return a + b + 1;
        }
    }
