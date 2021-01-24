    [Export(typeof(IIntellisenseControllerProvider))]
    [ContentType("Disassembly")]
    [TextViewRole(PredefinedTextViewRoles.Debuggable)]
    internal sealed class MyInfoControllerProvider : IIntellisenseControllerProvider
    {
        [Import]
        private IQuickInfoBroker _quickInfoBroker = null;
        [Import]
        private IToolTipProviderFactory _toolTipProviderFactory = null;
        public IIntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            var provider = this._toolTipProviderFactory.GetToolTipProvider(textView);
            return new MyInfoController(textView, subjectBuffers, this._quickInfoBroker, provider);
        }
    }
