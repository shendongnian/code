    var mock = new Mock<IOrderService>(MockBehavior.Loose);
    
    var newCalled = false;
    var openCalledBeforeNew = false;
    
    mock.Setup(x => x.UpdateOrderAsync(It.Is<Order>(o => o.State == "new"))).Callback(() => newCalled = !openCalledBeforeNew).Returns(Task.FromResult((object)null));
    mock.Setup(x => x.UpdateOrderAsync(It.Is<Order>(o => o.State == "open"))).Callback(() => openCalledBeforeNew = newCalled).Returns(Task.FromResult((object)null));
                
    await new Program().RunAsync(mock.Object);
    
    Assert.IsTrue(newCalled);
    Assert.IsTrue(openCalledBeforeNew);
