    [TestClass]
    public class XForwardedForRewriterTests {
        [TestMethod]
        public void Request_Should_Abort() {
            //Arrange
            var request = Mock.Of<HttpRequestBase>();
            var sut = new XForwardedForRewriter();
            //replace with mock request for test
            sut.GetRequest = (object sender) => request;
            //Act
            sut.Context_BeginRequest(new object(), EventArgs.Empty);
            //Assert
            var mockRequest = Mock.Get(request);
            mockRequest.Verify(m => m.Abort(), Times.AtLeastOnce);
        }
    
        [TestMethod]
        public void Request_Should_Forward() {
            //Arrange
            var request = Mock.Of<HttpRequestBase>();
            var mockRequest = Mock.Get(request);
            //setup mocked request with desired behavior for test
            var proxyv2HeaderStartRequence = new byte[12] { 0x0D, 0x0A, 0x0D, 0x0A, 0x00, 0x0D, 0x0A, 0x51, 0x55, 0x49, 0x54, 0x0A };
            mockRequest
                .Setup(m => m.BinaryRead(12))
                .Returns(proxyv2HeaderStartRequence);
            var fakeProxyv2IpvType = new byte[5] { 0x00, 0x12, 0x00, 0x00, 0x00 };
            mockRequest
                .Setup(m => m.BinaryRead(5))
                .Returns(fakeProxyv2IpvType);
            var headers = new NameValueCollection();
            mockRequest.Setup(m => m.Headers).Returns(headers);
            var sut = new XForwardedForRewriter();
            //replace with mock request for test
            sut.GetRequest = (object sender) => request;
            //Act
            sut.Context_BeginRequest(new object(), EventArgs.Empty);
            //Assert
            //...check request headers
            var xForwardedFor = headers["X-Forwarded-For"];
            Assert.IsNotNull(xForwardedFor);
        }
    }
