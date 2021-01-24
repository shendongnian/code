    _headers = new HeaderDictionary();
    
    var httpResponseMock = new Mock<HttpResponse>();
    httpResponseMock.Setup(mock => mock.Headers).Returns(_headers);
    
    var httpContextMock = new Mock<HttpContext>();
    httpContextMock.Setup(mock => mock.Response).Returns(httpResponseMock.Object);
    
    _purchaseController = new PurchaseController
    {
        ControllerContext = new ControllerContext 
        {
            HttpContext = httpContextMock.Object
        }
    }
