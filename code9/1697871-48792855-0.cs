    public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, Microsoft.VisualStudio.Shell.Interop.IVsWindowFrame pFrame)
    {
        try
        {
            if (GetDocumentName(docCookie).EndsWith(fileToBlock, System.StringComparison.CurrentCultureIgnoreCase))
                pFrame.CloseFrame((int)Microsoft.VisualStudio.Shell.Interop.__FRAMECLOSE.FRAMECLOSE_NoSave);
        }
        catch (System.Exception e)
        {
        }
        return Microsoft.VisualStudio.VSConstants.S_OK;
    }
