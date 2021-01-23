            var messenger = new Messenger();
            var bar = new Mock<Foo.IBar>();
            bar.Setup(x => x.Messenger).Returns(messenger);
            var fooMock = new Mock<Foo> { CallBase = true };
            //fooMock.SetupAllProperties();
            fooMock.Object.Bar = bar.Object;
            fooMock.VerifySet(s => s.Bar = It.IsAny<Foo.IBar>(), Times.AtLeastOnce()); // Success
            messenger.Send(new Foo.MyMessage());
            fooMock.Verify(c => c.SomeMethod(), Times.Once);  // Works
