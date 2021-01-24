    byte[] GetVersionWrapper(IntPtr hComHandle)
    {
        IntPtr pVersionBuffer = IntPtr.Zero;
        try
        {
          int len = 0;
          int status = MT123_GetVersion(hComHandle, IntPtr.Zero, ref len);
          if(status != 0) throw new Exception("message here");
          if(len < 0 || len > 1024) throw new Exception("message here");
          pVersionBuffer = Marshal.AllocCoTaskMem(len);
          int status = MT123_GetVersion(hComHandle, IntPtr.Zero, ref len);
          if(status != 0) throw new Exception("message here");
          byte[] retVal = new byte[len];
          Marshal.Copy(pVersionBuffer, retVal, 0, len);
          return retVal;
        }
        finally
        {
          Marshal.FreeCoTaskMem(pVersionBuffer);
        }
    }
    
