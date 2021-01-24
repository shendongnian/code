    public class C : VisualCommanderExt.ICommand
    {
    	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    	{
            serviceProvider = package as System.IServiceProvider;
            Microsoft.VisualStudio.Text.Editor.IWpfTextView textView = GetTextView();
            Microsoft.VisualStudio.Text.SnapshotPoint caretPosition = textView.Caret.Position.BufferPosition;
            textView.TextBuffer.Insert(caretPosition.Position, "sample code");
        }
    
        private Microsoft.VisualStudio.Text.Editor.IWpfTextView GetTextView()
        {
            Microsoft.VisualStudio.TextManager.Interop.IVsTextManager textManager =
                (Microsoft.VisualStudio.TextManager.Interop.IVsTextManager)serviceProvider.GetService(
                    typeof(Microsoft.VisualStudio.TextManager.Interop.SVsTextManager));
            Microsoft.VisualStudio.TextManager.Interop.IVsTextView textView;
            textManager.GetActiveView(1, null, out textView);
            return GetEditorAdaptersFactoryService().GetWpfTextView(textView);
        }
    
        private Microsoft.VisualStudio.Editor.IVsEditorAdaptersFactoryService GetEditorAdaptersFactoryService()
        {
            Microsoft.VisualStudio.ComponentModelHost.IComponentModel componentModel =
                (Microsoft.VisualStudio.ComponentModelHost.IComponentModel)serviceProvider.GetService(
                    typeof(Microsoft.VisualStudio.ComponentModelHost.SComponentModel));
            return componentModel.GetService<Microsoft.VisualStudio.Editor.IVsEditorAdaptersFactoryService>();
        }
    
        private System.IServiceProvider serviceProvider;
    }
