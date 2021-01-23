    [TestMethod]
    public async Task TestMethod1()
    {
      var mock = new Mock<IOrderService>();
      Order o1 = new Order() { State = "new" };
      int countOrderStateNew = 0;
      int countOrderStateOpen = 0;
      mock.Setup(a => a.UpdateOrderAsync(It.Is<Order>(o => o.State == "new")))
          .Returns(Task.Factory.StartNew(() => { }))
          .Callback(() => countOrderStateNew++);
      mock.Setup(a => a.UpdateOrderAsync(It.Is<Order>(o => o.State == "open")))
          .Returns(Task.Factory.StartNew(() => { }))
          .Callback(()=> countOrderStateOpen++);
      await new Program().RunAsync(mock.Object);
      Assert.AreEqual(1, countOrderStateNew);
      Assert.AreEqual(1, countOrderStateOpen);
    }
