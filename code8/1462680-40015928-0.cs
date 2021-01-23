    static internal bool SaveEnhMetafileToFile(Metafile mf, string fileName)
    {
      bool bResult = false;
      IntPtr hEMF;
      hEMF = mf.GetHenhmetafile(); // invalidates mf 
      if (!hEMF.Equals(new IntPtr(0)))
      {
        StringBuilder tempName = new StringBuilder(fileName);
        IntPtr hCopyEMF = CopyEnhMetaFile(hEMF, tempName);
        DeleteEnhMetaFile(hCopyEMF);
        DeleteEnhMetaFile(hEMF);
      }
    return bResult;
    }
