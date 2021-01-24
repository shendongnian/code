    public int CreateEditorInstance(uint grfCreateDoc, string pszMkDocument, string pszPhysicalView, IVsHierarchy pvHier, uint itemid, IntPtr punkDocDataExisting, out IntPtr ppunkDocView, out IntPtr ppunkDocData, out string pbstrEditorCaption, out Guid pguidCmdUI, out int pgrfCDW)
    {
        ppunkDocView = IntPtr.Zero;
        ppunkDocData = IntPtr.Zero;
        pbstrEditorCaption = null;
        pguidCmdUI = Guid.Empty;
        pgrfCDW = 0;
        // create your virtual Xml buffer
        var data = _package.CreateComInstance<VsTextBufferClass, IVsTextLines>();
        SiteObject(data);
        // this is where you build your virtual Xml content from your binary data
        string myXml = "<root>blah</root>";
        data.InitializeContent(myXml, myXml.Length);
        var dataPtr = Marshal.GetIUnknownForObject(data);
        // build a document and register it in the Running Object Table
        // this document has no hierarchy (it will be handled by the 'Miscellaneous Files' fallback project)
        var rotFlags = _VSRDTFLAGS.RDT_ReadLock | _VSRDTFLAGS.RDT_VirtualDocument;
        // come up with a moniker (which will be used as the caption also by the Xml editor)
        // the .xml extension here is important, it's what determines what editor to use by default
        // Note I presume the moniker is a file path, wich may not always be ok depending on your context
        var virtualMk = Path.ChangeExtension(pszMkDocument, ".xml");
        var rot = (IVsRunningDocumentTable)_serviceProvider.GetService(typeof(SVsRunningDocumentTable));
        int hr = rot.RegisterAndLockDocument((uint)rotFlags, virtualMk, null, VSConstants.VSITEMID_NIL, dataPtr, out uint docCookie);
        if (hr != 0)
            return hr;
        // handle events using the rot
        var docEventHandler = new RotDocumentEvents(docCookie);
        docEventHandler.Saving += (sender, e) =>
            {
                // this is where you can get the content of the data and save your binary data back
                // you can use Saved or Saving
            };
        rot.AdviseRunningDocTableEvents(docEventHandler, out uint rootCookie);
        // ask Visual Studio to open that document
        var opener = (IVsUIShellOpenDocument)_serviceProvider.GetService(typeof(SVsUIShellOpenDocument));
        var view = VSConstants.LOGVIEWID_Primary;
        opener.OpenDocumentViaProject(virtualMk, ref view,
            out Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp,
            out IVsUIHierarchy uiHier,
            out uint id,
            out IVsWindowFrame frame);
        if (frame != null)
        {
            frame.Show();
        }
        return VSConstants.S_OK;
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
        public int OnBeforeLastDocumentUnlock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)=> VSConstants.S_OK;
        public int OnAfterAttributeChange(uint docCookie, uint grfAttribs) => VSConstants.S_OK;
        public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame) => VSConstants.S_OK;
        public int OnAfterDocumentWindowHide(uint docCookie, IVsWindowFrame pFrame) =>VSConstants.S_OK;
        public int OnAfterAttributeChangeEx(uint docCookie, uint grfAttribs, IVsHierarchy pHierOld, uint itemidOld, string pszMkDocumentOld, IVsHierarchy pHierNew, uint itemidNew, string pszMkDocumentNew) => VSConstants.S_OK;
    }
