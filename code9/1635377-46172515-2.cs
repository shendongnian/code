        internal class WriteImpl : IWrite
    {
        private IExistingReadWrite worker;
        internal FooWriteImpl(IExistingReadWrite i)
        {
            worker = i;
        }
        public string width
        {
            get { throw new Exception("Dave I cannot let you do that");}
            set { worker.width = value; }
        }
    }
