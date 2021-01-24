    private IWpfTextView GetWpfView()
    {
            var textManager = (IVsTextManager)ServiceProvider.GetService(typeof(SVsTextManager));
            var componentModel = (IComponentModel)this.ServiceProvider.GetService(typeof(SComponentModel));
            var editor = componentModel.GetService<IVsEditorAdaptersFactoryService>();
            textManager.GetActiveView(1, null, out IVsTextView textViewCurrent);
            return editor.GetWpfTextView(textViewCurrent);
    }
