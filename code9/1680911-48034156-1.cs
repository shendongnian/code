    byte[] GetVersionWrapper(IntPtr hComHandle)
    {
        IntPtr pVersionBuffer = IntPtr.Zero;
        try
        {
          int len = 0;
          // First retrieve the length
          int status = MT123_GetVersion(hComHandle, IntPtr.Zero, ref len);
          if(status != 0) throw new Exception("message here");
          if(len < 0 || len > 1024) throw new Exception("message here");
          // Now allocate a buffer of the given length.
          pVersionBuffer = Marshal.AllocCoTaskMem(len);
          // Now retrieve the version information into the buffer
          int status = MT123_GetVersion(hComHandle, pVersionBuffer, ref len);
          if(status != 0) throw new Exception("message here");
          // Now copy the version information to a managed array.
          byte[] retVal = new byte[len];
          Marshal.Copy(pVersionBuffer, retVal, 0, len);
          // Return the managed array.
          return retVal;
        }
        finally
        {
          // done in Finally in case anything above throws an exception.
          Marshal.FreeCoTaskMem(pVersionBuffer);
        }
    }
    
