    public class Transfer 
    {
        public virtual IReadOnlyList<SubTransfer> SubTransfers { get; private set; }
        public void SetSubTransfers(List<SubTransfer> subTransfers)
        {
            SubTransfers = subTransfers;
        }
    }
    public class ExtendedTransfer
    {
        private List<ExtendedSubTransfer> _subTransfers;
        public override IReadOnlyList<SubTransfer> SubTransfers
        {
            get { return _subTransfers; }
        }
        public void SetSubTransfers(List<ExtendedSubTransfer> subTransfers)
        {
            _subTransfers = subTransfers;
        }
    }
