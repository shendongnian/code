    public class MessageBoxWindowAutomationPeer : WindowAutomationPeer
    {
        private const string WC_DIALOG = "#32770";
        public MessageBoxWindowAutomationPeer(Window owner)
            : base(owner)
        {
        }
        protected override string GetClassNameCore()
        {
            return WC_DIALOG;
        }
        protected override string GetLocalizedControlTypeCore()
        {
            return "Dialogfeld";
        }
        protected override bool IsContentElementCore()
        {
            return true;
        }
        protected override bool IsControlElementCore()
        {
            return true;
        }
    }
