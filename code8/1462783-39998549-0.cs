    [TestMethod]
    public void Test()
    {
      var expected = new ServiceItem();
      var mockDomain = new Mock<IDomain>();
      var expectedDomainReturn = new DomainItem(0); //Illustrative purposes only
      mockDomain.Setup(x => x.DomainCall(0)).Returns(expectedDomainReturn); //Illustrative purposes only
      var mockMapper = new Mock<IMapper>();
      mockMapper.Setup(x => x.Map<DomainItem, ServiceItem>(It.IsAny<DomainItem>()))
          .Returns(expected);    
      var service = new Service(mockDomain.Object, mockMapper.Object);
      var result = service.Get(0);
      mockDomain.Verify(x => x.DomainCall(0), Times.Once);
      mockMapper.Verify(x => x.Map<DomainItem, ServiceItem>(expectedDomainReturn), Times.Once);
    }
