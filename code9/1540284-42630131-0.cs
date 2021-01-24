    public WriteableBitmap GetBitmapPath(ulong sessionID)
    {
      WriteableBitmap bmp = null;
      try
      {
        int          width;
        int          height;
        System.Array sa;
        gs.GetPathBmp(sessionID, out width, out height, out sa);
        bmp = BitmapFactory.New(width, height);
        byte[] data = new byte[sa.Length];
        sa.CopyTo(data, 0);
        bmp.FromByteArray(data);
      }
      catch (Exception e)
      {
        System.Diagnostics.Trace.WriteLine(String.Format("GetBitmapPath failed, session ID {0} - {1}", sessionID, e.Message));
      }
      return bmp;
    }
