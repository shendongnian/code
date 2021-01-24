    [Test]
    public void EnsureSomeActionOnOrderDoesIt()
    {
       var uowMock = new Mock<IUnitOfWork>();
       var uowFactoryMock = new Mock<IUnitOfWorkFactory>();
       var repositoryMock = new Mock<IOrderRepository>();
       var testOrderId = -1;
       var stubOrders = new [] { newOrder { /* populate expected data... */ } };
       
       uowMock.Setup(x=>x.Commit());
       uowFactoryMock.Setup(x=>x.Create()).Returns(uowMock.Object);
       repositoryMock.Setup(x=>x.GetOrderById(testOrderId)).Returns(stubOrders.AsQueryable());
    
       var testController = new OrderController(uowFactoryMock.Object, repositoryMock.Object);
       testController.SomeActionOnOrder(testOrderId);
    
       // Everything "touched" as expected? (did the code fetch the object? did it save the changes?)
       uowFactoryMock.VerifyAll();
       uowMock.VerifyAll();
       repositoryMock.VerifyAll();
    
       // Perform asserts on your stub order if SomeAction modified state as you expected.
    }
