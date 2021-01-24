     [Fact]
            public void Test() {
                // arrange
                var fixture = new Fixture()
                 .Customize(new AutoMoqCustomization())
                 .Customize(new ServiceProviderCustomization());
    
                fixture.Freeze<Mock<IPersonRepository>>()
                    .Setup(m => m.GetById(It.IsAny<int>()))
                    .Returns(new Person(Name = "John"));
    
                // Act
                var apiResource = _fixture.Create<ApiResourceRepository>();
                var person = apiResource.Get(1);
    
                // Assert
                ...
            }
