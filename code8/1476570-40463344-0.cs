    [Test]
        public void it_should_do()
        {
            var myController = new Mock<MyController> { CallBase = true };
            myController.Save(myMessage);
            myController.Verify(m => m.RedirectToRouteResult(It.IsAny<string>(), It.IsAny<Message>()), Times.Once);
            myController.Verify(m => m.RedirectToRouteResult("SendEmail", myMessage), Times.Once);
        }
