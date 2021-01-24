    public class InMemoryRepository : IRepository<ConcreteType> {
        private HashSet<ConcreteType> _data = new HashSet<ConcreteType>();
        private Mock<IMongoQueryable<ConcreteType>> _mongoQueryableMock;
    
        public ReviseMeasureRepository() {    
            var queryableList = _data.AsQueryable();
        
            _mongoQueryableMock = new Mock<IMongoQueryable<ConcreteType>>();
            _mongoQueryableMock.As<IQueryable<ConcreteType>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            _mongoQueryableMock.As<IQueryable<ConcreteType>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            _mongoQueryableMock.As<IQueryable<ConcreteType>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            _mongoQueryableMock.As<IQueryable<ConcreteType>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());    
        }
    
        public IMongoQueryable<ConcreteType> Get() {
            return _mongoQueryableMock.Object;
        }
    
        //...
    }
