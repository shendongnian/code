        [Test()]
        public void Test()
        {
            var httpContextMock = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            httpContextMock.SetupGet(x => x.Request).Returns(request.Object);
            httpContextMock.SetupGet(x => x.Request.Files.Count).Returns(2);
            var count = httpContextMock.Object.Request.Files.Count;
            Assert.AreEqual(2, count);
        }
            
