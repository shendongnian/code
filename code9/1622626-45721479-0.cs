    var componentModel = (IComponentModel)Package.GetGlobalService(typeof(SComponentModel));
    var textManager = (IVsTextManager)Package.GetGlobalService(typeof(SVsTextManager));
    IVsTextView activeView = null;
    ErrorHandler.ThrowOnFailure(textManager.GetActiveView(1, null, out activeView));
    var editorAdapter = componentModel.GetService<IVsEditorAdaptersFactoryService>();
    var textView = editorAdapter.GetWpfTextView(activeView);
    var document  = Extensions.GetRelatedDocuments(textView.TextBuffer).FirstOrDefault();
