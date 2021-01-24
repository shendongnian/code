    static unsafe void Monitor(byte[] buffer)
    {
         
        Overlapped overlapped = new Overlapped();
  
        // notice how the buffer goes here as instance member on AsyncResult.
        // Arrays are still Reference types.      
        overlapped.AsyncResult = new AsyncResult { buffer = buffer };
        // CompletionStatusChanged is the method that will be called
        // when filechanges are detected
        NativeOverlapped* statusChanged = overlapped.Pack(new IOCompletionCallback(CompletionStatusChanged), buffer);
        fixed (byte* ptr2 = buffer)
        {
            int num;
            // this where the magic starts
            NativeMethods.ReadDirectoryChangesW(hndl, 
              new HandleRef(instance, (IntPtr)((void*)ptr2)), 
              buffer.Length, 
              1, 
              (int)(NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Attributes), 
              out num, 
              statusChanged, 
              new HandleRef(null, IntPtr.Zero));
        }
       
    }
