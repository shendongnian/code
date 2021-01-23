    class MorgType : ReaderDecorator
    {
        public MorgType(MorgReader wrapped) : base(wrapped)
        { }
        protected override string ReadImpl()
        {
            return "type";
        }
    }
