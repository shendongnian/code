      public static class iop
      {
    
      [DllImport("InteropyDll1.dll",  CallingConvention = CallingConvention.StdCall)]
        unsafe public static extern void Calculate(int argc, void** argv);
    
        unsafe static public void Compute()
        {
            int X, Y, iterations;
            bool Resize;
            double* Input = (double*)IntPtr.Zero;
    
            // Initialize variables, allocate data for Input
            // ...
    
            void **Parameters = stackalloc void*[7];
    
            Parameters[0] = &X;
            Parameters[1] = &Y;
            Parameters[2] = &iterations;
            Parameters[3] = &Resize;
            Parameters[4] = Input;
            Parameters[5] = &X;
            Parameters[6] = &Y;
    
            Calculate(7, Parameters);
        }
      }
