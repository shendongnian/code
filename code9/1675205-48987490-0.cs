    // get global UI shell service from a service provider
    var shell = (IVsUIShell)ServiceProvider.GetService(typeof(SVsUIShell));
    // try to find the C# interactive Window frame from it's package Id
    var CSharpVsInteractiveWindowPackageId = new Guid("{ca8cc5c7-0231-406a-95cd-aa5ed6ac0190}");
    // you can use a flag here to force open it
    var flags = __VSFINDTOOLWIN.FTW_fFindFirst;
    shell.FindToolWindow((uint)flags, ref CSharpVsInteractiveWindowPackageId, out IVsWindowFrame frame);
    // available?
    if (frame != null)
    {
        // get its view (it's a WindowPane)
        frame.GetProperty((int)__VSFPROPID.VSFPROPID_DocView, out object dv);
        // this pane implements IVsInteractiveWindow (you need to add the Microsoft.VisualStudio.VsInteractiveWindow nuget package)
        var iw = (IVsInteractiveWindow)dv;
        // now get the wpf view host
        // using an extension method from Microsoft.VisualStudio.VsInteractiveWindowExtensions class
        IWpfTextViewHost host = iw.InteractiveWindow.GetTextViewHost();
        // you can get lines with this
        var lines = host.TextView.TextViewLines;
        // and subscribe to events in text with this
        host.TextView.TextBuffer.Changed += TextBuffer_Changed;
    }
    private void TextBuffer_Changed(object sender, TextContentChangedEventArgs e)
    {
        // text has changed
    }
