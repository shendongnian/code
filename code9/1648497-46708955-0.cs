    var dataQueryable = data.AsQueryable();
            _mongoQueryableMock = new Mock<IMongoQueryable<T>>(MockBehavior.Strict);
            _mongoQueryableMock.Setup(r => r.GetEnumerator()).Returns(data.GetEnumerator());
            _mongoQueryableMock.Setup(r => r.Provider).Returns(dataQueryable.Provider);
            _mongoQueryableMock.Setup(r => r.ElementType).Returns(dataQueryable.ElementType);
            _mongoQueryableMock.Setup(r => r.Expression).Returns(dataQueryable.Expression);
