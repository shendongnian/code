    /// <summary>
    /// is using the <see cref="FileLayoutEx"/> class.
    /// </summary>
    [Target("FileTargetEx")]
    internal class FileTargetEx : FileTarget
    {
        public override Layout Layout
        {
            get => _Layout;
            set
            {
                base.Layout = new FileLayoutEx((value as SimpleLayout).OriginalText);
                _Layout = new FileLayoutEx((value as SimpleLayout).OriginalText);
            }
        }
        private Layout _Layout;
        public FileTargetEx()
        {
            Footer = new FileLayoutEx();
            Header = new FileLayoutEx();
        }
    }
    /// <summary>
    /// Provides a formated message (Exception included!).
    /// </summary>
    [Layout("FileLayoutEx")]
    internal class FileLayoutEx : SimpleLayout
    {
        public FileLayoutEx() { }
        public FileLayoutEx(string originalText) : base(originalText) { }
        protected override string GetFormattedMessage(LogEventInfo logEvent)
        {
            //Extension method is outsourced
            LogEventInfo updatedInfo = logEvent.GetFormattedMessage();
            return base.GetFormattedMessage(updatedInfo);
        }
    }
