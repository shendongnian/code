    public interface IDataIndexator { }
    public delegate object Update(IDataIndexator[] regs);
    public abstract class SimpleElement<TDataIndexer> where TDataIndexer : IDataIndexator
    {
        public TDataIndexer[] po_registr;
        protected Update updateDelegate;
        public void foo()
        {
            this.updateDelegate(po_registr.Cast<IDataIndexator>().ToArray()); // here is error that parameter should be IDataIndexator[], but not TDataIndexer[]
        }
    }
