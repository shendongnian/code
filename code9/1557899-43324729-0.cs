    public class ReadOnlyControlCollection : Control.ControlCollection
    {
        public ReadOnlyControlCollection(Control owner)
            : base(owner)
        {
        }
        public override bool IsReadOnly
        {
            get { return true; }
        }
        public override void Add(Control control)
        {
            throw new ArgumentException("control");
        }
    }
