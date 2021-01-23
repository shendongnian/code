    class MorgType : ReaderDecorator
    {
        public MorgType(MorgReader wrapped) : base(wrapped)
        { }
        public override string Read()
        {
            return WrappedReader == null ? "type" : WrappedReader.Read() + ",type";
        }
    }
    class MorgXY : ReaderDecorator
    {
        public MorgXY(MorgReader wrapped) : base(wrapped)
        { }
        public override string Read()
        {
            return WrappedReader == null ? "x,y" : WrappedReader.Read() + ",x,y";
        }
    }
    class MorgMovement : ReaderDecorator
    {
        public MorgMovement(MorgReader wrapped) : base(wrapped)
        { }
        public override string Read()
        {
            return WrappedReader == null ? "paddle" : WrappedReader.Read() + ",paddle";
        }
    }
