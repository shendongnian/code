    public static IWpfTextView GetCurrentTextView(Package package)
    {
        try
        {
            var serviceProvider = package as IServiceProvider;
            IVsTextManager textManager = (IVsTextManager)serviceProvider.GetService(typeof(SVsTextManager));
            IVsTextView textView;
            textManager.GetActiveView(1, null, out textView);
            IComponentModel componentModel = (IComponentModel)serviceProvider.GetService(typeof(SComponentModel));
            var factoryService = componentModel.GetService<IVsEditorAdaptersFactoryService>();
            return factoryService.GetWpfTextView(textView);
        }
        catch
        {
            return null;
        }
    }
