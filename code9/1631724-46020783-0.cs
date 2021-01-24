    public interface IDeskBand2 : IDeskBand
    {
        // IOleWindow
        new int GetWindow(out IntPtr phwnd);
        new int ContextSensitiveHelp(bool fEnterMode);
        // IDockingWindow
        new int ShowDW(bool bShow);
        new int CloseDW(UInt32 dwReserved);
        new int ResizeBorderDW(RECT rcBorder, IntPtr punkToolbarSite, bool fReserved);
        // IDeskBand
        new int GetBandInfo(UInt32 dwBandID, DESKBANDINFO.DBIF dwViewMode, ref DESKBANDINFO pdbi);
        // IDeskBand2
        int CanRenderComposited(out bool pfCanRenderComposited);
        ....
    }
