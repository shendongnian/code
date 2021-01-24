    public static class Packager
    {
      public static void PackageFile(string outputFile, string outputImageFile, string inputFile)
      {
          if (outputFile == null)
              throw new ArgumentNullException(nameof(outputFile));
          if (outputImageFile == null)
              throw new ArgumentNullException(nameof(outputImageFile));
          if (inputFile == null)
              throw new ArgumentNullException(nameof(inputFile));
          IStorage storage;
          CheckHr(StgCreateStorageEx(
              outputFile,
              STGM_CREATE | STGM_READWRITE | STGM_SHARE_EXCLUSIVE,
              STGFMT_DOCFILE,
              0,
              IntPtr.Zero,
              IntPtr.Zero,
              typeof(IStorage).GUID,
              out storage));
          // note 1: if you get 'Use of Ole1 services requiring DDE windows is disabled' error, make sure the executing thread is STA
          //
          // note 2: if you want packager to succeed on PDF files instead of reporting 0x8000ffff (E_UNEXPECTED), make sure
          // there exists a key named "PackageOnFileDrop", like this: HKEY_CLASSES_ROOT\AcroExch.Document.DC\PackageOnFileDrop
          //
          IDataObject ps; // from System.Runtime.InteropServices.ComTypes
          CheckHr(OleCreateFromFile(
              Guid.Empty,
              inputFile,
              typeof(IDataObject).GUID,
              0,
              IntPtr.Zero,
              IntPtr.Zero,
              storage,
              out ps));
          var format = new FORMATETC();
          format.cfFormat = CF_ENHMETAFILE;
          format.dwAspect = DVASPECT.DVASPECT_CONTENT;
          format.lindex = -1;
          format.tymed = TYMED.TYMED_ENHMF;
          STGMEDIUM medium;
          ps.GetData(ref format, out medium);
          CopyEnhMetaFile(medium.unionmember, outputImageFile);
          DeleteEnhMetaFile(medium.unionmember);
          storage.Commit(0);
          Marshal.FinalReleaseComObject(ps);
          Marshal.FinalReleaseComObject(storage);
      }
      private static void CheckHr(int hr)
      {
          if (hr != 0)
              throw new Win32Exception(hr);
      }
      [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000000B-0000-0000-C000-000000000046")]
      private interface IStorage
      {
          void _VtblGap1_6(); // we only need Commit
          void Commit(int grfCommitFlags);
      }
      [DllImport("ole32.dll")]
      private static extern int StgCreateStorageEx(
          [MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
          int grfMode,
          int stgfmt,
          int grfAttrs,
          IntPtr pStgOptions,
          IntPtr reserved2,
          [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
          out IStorage ppObjectOpen);
      [DllImport("ole32.dll")]
      private static extern int OleCreateFromFile(
          [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
          [MarshalAs(UnmanagedType.LPWStr)] string lpszFileName,
          [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
          int renderopt,
          IntPtr lpFormatEtc,
          IntPtr pClientSite,
          IStorage pStg,
          out IDataObject ppStg
          );
      [DllImport("gdi32.dll", SetLastError = true)]
      private static extern bool DeleteEnhMetaFile(IntPtr hemf);
      [DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
      private static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, string lpszFile);
      private const int CF_ENHMETAFILE = 14;
      private const int STGM_READWRITE = 2;
      private const int STGM_SHARE_EXCLUSIVE = 0x10;
      private const int STGM_CREATE = 0x1000;
      private const int STGFMT_DOCFILE = 5;
    }
