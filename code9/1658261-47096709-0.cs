    public class TheFactory
    {
        public TheFactory( SomeType fromContainer )
        {
            _fromContainer = fromContainer;
        }
        public IProduct Create( SomeOtherType notFromContainer ) => new TheProduct( _fromContainer, notFromContainer );
        private readonly SomeType _fromContainer;
        private class TheProduct : IProduct
        {
            // ...
        }
    }
