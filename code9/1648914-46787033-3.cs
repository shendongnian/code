    public int CreateEditorInstance(uint grfCreateDoc, string pszMkDocument, string pszPhysicalView, IVsHierarchy pvHier, uint itemid, IntPtr punkDocDataExisting, out IntPtr ppunkDocView, out IntPtr ppunkDocData, out string pbstrEditorCaption, out Guid pguidCmdUI, out int pgrfCDW)
    {
        ppunkDocView = IntPtr.Zero;
        ppunkDocData = IntPtr.Zero;
        pbstrEditorCaption = null;
        pguidCmdUI = Guid.Empty;
        pgrfCDW = 0;
        // create your virtual Xml buffer
        var data = Package.CreateComInstance<VsTextBufferClass, IVsTextLines>();
        SiteObject(data);
        // this is where you're supposed to build your virtual Xml content from your binary data
        string myXml = "<root>blah</root>";
        data.InitializeContent(myXml, myXml.Length);
        var dataPtr = Marshal.GetIUnknownForObject(data);
        // build a document and register it in the Running Object Table
        // this document has no hierarchy (it will be handled by the 'Miscellaneous Files' fallback project)
        var rotFlags = _VSRDTFLAGS.RDT_ReadLock | _VSRDTFLAGS.RDT_VirtualDocument;
        // come up with a moniker (which will be used as the caption also by the Xml editor)
        // Note I presume the moniker is a file path, wich may not always be ok depending on your context
        var virtualMk = Path.ChangeExtension(pszMkDocument, ".xml");
        var rot = (IVsRunningDocumentTable)_sp.GetService(typeof(SVsRunningDocumentTable));
        int hr = rot.RegisterAndLockDocument((uint)rotFlags, virtualMk, null, VSConstants.VSITEMID_NIL, dataPtr, out uint docCookie);
        if (hr != 0)
            return hr;
        try
        {
            // ask Visual Studio to open that document
            var opener = (IVsUIShellOpenDocument)_sp.GetService(typeof(SVsUIShellOpenDocument));
            var view = VSConstants.LOGVIEWID_Primary;
            opener.OpenDocumentViaProject(virtualMk, ref view,
                out Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp,
                out IVsUIHierarchy uiHier,
                out uint id,
                out IVsWindowFrame frame);
            if (frame != null)
            {
                // Hmm.. the dirty bit (the star after the caption) is not updated by the Xml Editor...
                // If you close the document (or close VS), it does update it, but it does not react when we type in the editor.
                // This is unexpected, so, let's do the "dirty" work ourselves
                // hook on text line events from the buffer
                var textLineEvents = new TextLineEvents((IConnectionPointContainer)data);
                // we want to know when to unadvise, to hook frame events too
                ((IVsWindowFrame2)frame).Advise(textLineEvents, out uint frameCookie);
                textLineEvents.LineTextChanged += (sender, e) =>
                {
                    // get the dirty bit and override the frame's dirty state
                    ((IVsPersistDocData)data).IsDocDataDirty(out int dirty);
                    frame.SetProperty((int)__VSFPROPID2.VSFPROPID_OverrideDirtyState, dirty != 0 ? true : false);
                };
                // now handle save events using the rot
                var docEventHandler = new RotDocumentEvents(docCookie);
                docEventHandler.Saving += (sender, e) =>
                {
                    // this is where you can get the content of the data and save your binary data back
                    // you can use Saved or Saving
                };
                docEventHandler.Saved += (sender, e) =>
                {
                    // manual reset of dirty bit...
                    frame.SetProperty((int)__VSFPROPID2.VSFPROPID_OverrideDirtyState, false);
                };
                rot.AdviseRunningDocTableEvents(docEventHandler, out uint rootCookie);
                frame.Show();
            }
        }
        finally
        {
            rot.UnlockDocument((uint)_VSRDTFLAGS.RDT_ReadLock, docCookie);
        }
        return VSConstants.S_OK;
    }
    private class TextLineEvents : IVsTextLinesEvents, IVsWindowFrameNotify, IVsWindowFrameNotify2
    {
        public event EventHandler LineTextChanged;
        private uint _cookie;
        private IConnectionPoint _cp;
        public TextLineEvents(IConnectionPointContainer cpc)
        {
            var textLineEventsGuid = typeof(IVsTextLinesEvents).GUID;
            cpc.FindConnectionPoint(ref textLineEventsGuid, out _cp);
            _cp.Advise(this, out _cookie);
        }
        public void OnChangeLineText(TextLineChange[] pTextLineChange, int fLast) => LineTextChanged?.Invoke(this, EventArgs.Empty);
        public int OnClose(ref uint pgrfSaveOptions)
        {
            _cp.Unadvise(_cookie);
            return VSConstants.S_OK;
        }
        public void OnChangeLineAttributes(int iFirstLine, int iLastLine) { }
        public int OnShow(int fShow) => VSConstants.S_OK;
        public int OnMove() => VSConstants.S_OK;
        public int OnSize() => VSConstants.S_OK;
        public int OnDockableChange(int fDockable) => VSConstants.S_OK;
    }
    private class RotDocumentEvents : IVsRunningDocTableEvents3
    {
        public event EventHandler Saved;
        public event EventHandler Saving;
        public RotDocumentEvents(uint docCookie)
        {
            DocCookie = docCookie;
        }
        public uint DocCookie { get; }
        public int OnBeforeSave(uint docCookie)
        {
            if (docCookie == DocCookie)
            {
                Saving?.Invoke(this, EventArgs.Empty);
            }
            return VSConstants.S_OK;
        }
        public int OnAfterSave(uint docCookie)
        {
            if (docCookie == DocCookie)
            {
                Saved?.Invoke(this, EventArgs.Empty);
            }
            return VSConstants.S_OK;
        }
        public int OnAfterFirstDocumentLock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining) => VSConstants.S_OK;
        public int OnBeforeLastDocumentUnlock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining) => VSConstants.S_OK;
        public int OnAfterAttributeChange(uint docCookie, uint grfAttribs) => VSConstants.S_OK;
        public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame) => VSConstants.S_OK;
        public int OnAfterDocumentWindowHide(uint docCookie, IVsWindowFrame pFrame) => VSConstants.S_OK;
        public int OnAfterAttributeChangeEx(uint docCookie, uint grfAttribs, IVsHierarchy pHierOld, uint itemidOld, string pszMkDocumentOld, IVsHierarchy pHierNew, uint itemidNew, string pszMkDocumentNew) => VSConstants.S_OK;
    }
