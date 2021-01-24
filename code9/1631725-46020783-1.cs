    public interface IDeskBand2
    {
        // IOleWindow
        int GetWindow(out IntPtr phwnd);
        int ContextSensitiveHelp(bool fEnterMode);
        // IDockingWindow
        int ShowDW(bool bShow);
        int CloseDW(UInt32 dwReserved);
        int ResizeBorderDW(RECT rcBorder, IntPtr punkToolbarSite, bool fReserved);
        // IDeskBand
        int GetBandInfo(UInt32 dwBandID, DESKBANDINFO.DBIF dwViewMode, ref DESKBANDINFO pdbi);
        // IDeskBand2
        int CanRenderComposited(out bool pfCanRenderComposited);
        ....
    }
