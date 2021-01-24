    class Program
    {
        private static IntPtr pv_Memory;
    
        static void Main(string[] args)
        {
            Console.ReadLine();
            for(int i=0;i<10;i++)
            {
                pv_Memory = Marshal.AllocHGlobal(0x200000);
            }
    
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            
        }
    }
