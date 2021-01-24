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
    public class XForwardedForRewriter : IHttpModule {
        public void Dispose() {
            throw new NotImplementedException();
        }
        byte[] proxyv2HeaderStartRequence = new byte[12] { 0x0D, 0x0A, 0x0D, 0x0A, 0x00, 0x0D, 0x0A, 0x51, 0x55, 0x49, 0x54, 0x0A };
        public void Init(HttpApplication context) {
            context.BeginRequest += Context_BeginRequest;
        }
        public Func<object, HttpRequestBase> GetRequest = (object sender) => {
            return new HttpRequestWrapper(((HttpApplication)sender).Context.Request);
        };
        public void Context_BeginRequest(object sender, EventArgs e) {
            var request = GetRequest(sender);
            var proxyv2header = request.BinaryRead(12);
            if (!proxyv2header.SequenceEqual(proxyv2HeaderStartRequence)) {
                request.Abort();
            } else {
                var proxyv2IpvType = request.BinaryRead(5).Skip(1).Take(1).Single();
                var isIpv4 = new byte[] { 0x11, 0x12 }.Contains(proxyv2IpvType);
                var ipInBinary = isIpv4 ? request.BinaryRead(12) : request.BinaryRead(36);
                var ip = Convert.ToString(ipInBinary);
                var headers = request.Headers;
                var hdr = headers.GetType();
                var ro = hdr.GetProperty("IsReadOnly",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.FlattenHierarchy);
                ro.SetValue(headers, false, null);
                hdr.InvokeMember("InvalidateCachedArrays",
                    BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
                    null, headers, null);
                hdr.InvokeMember("BaseAdd",
                    BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
                    null, headers,
                    new object[] { "X-Forwarded-For", new ArrayList { ip } });
                ro.SetValue(headers, true, null);
            }
        }
    }
