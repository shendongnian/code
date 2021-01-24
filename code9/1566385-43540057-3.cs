    public class csInterface
    {
        [DllImport(@"myDLL.dll", EntryPoint = "dllFunc", CallingConvention = CallingConvention.StdCall)]
        private static extern void dllFunc(IntPtr inp, IntPtr outp);
        public static int myDll(ref MyInput myInput, ref MyOutput myOutput)
        {
            int sizeIn, sizeOut;
            IntPtr ptr_i = IntPtr.Zero, ptr_u = IntPtr.Zero;
            sizeIn = Marshal.SizeOf(typeof(myInput));
            sizeOut = Marshal.SizeOf(typeof(myOutput));
            /* Calling C */
            try
            {
                ptr_i = Marshal.AllocHGlobal(sizeIn);
                ptr_u = Marshal.AllocHGlobal(sizeOut);
                Marshal.StructureToPtr(myInput, ptr_i, true);
                Marshal.StructureToPtr(myOutput, ptr_u, true);
                dllFunc(ptr_i, ptr_u);
                myOutput = (MyOutput)(Marshal.PtrToStructure(ptr_u, typeof(MyOutput)));
            }
            catch (Exception)
            {
                //Return something meaningful (or not)
                return -999;
            }
            finally
            {
                //Free memory
                Marshal.FreeHGlobal(ptr_i);
                Marshal.FreeHGlobal(ptr_u);
            }
            //Return something to indicate it all went well
            return 0;
        }
    }
