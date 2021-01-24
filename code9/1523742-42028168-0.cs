    public class ResultThrottlerStubBuilder<TType> where TType : ProductResult
    {
        private Mock<IResultThrottler> _resultThrottler;
        public IResultThrottler Build()
        {
            _resultThrottler = new Mock<IResultThrottler>();
            _resultThrottler
                .Setup(x => x.Throttle(It.IsAny<IEnumerable<TType>>(), It.IsAny<Guid>()))
                .Returns((IEnumerable<TType> input, Guid resultSetId) => input );
            return _resultThrottler.Object;
        }
    }
