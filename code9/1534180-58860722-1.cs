        delegate void OutDelegate<TIn, TOut>(TIn input, out TOut output);
        [Test]
        public void TestMethod()
        {
            // Arrange
            var _mockMemoryCache = new Mock<IMemoryCache>();
            object whatever;
            _mockMemoryCache
                .Setup(mc => mc.TryGetValue(It.IsAny<object>(), out whatever))
                .Callback(new OutDelegate<object, object>((object k, out object v) =>
                    v = new object())) // mocked value here (and/or breakpoint)
                .Returns(true); 
            // Act
            var result = _target.GetValueFromCache("key");
            // Assert
            // ...
        }
