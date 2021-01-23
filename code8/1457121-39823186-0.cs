    public class DecryptionMiddleWare : OwinMiddleware {
        private string expected;
        private string decryptedString;
        public DecryptionMiddleWare(OwinMiddleware next, string expected, string decryptedString)
            : base(next) {
            this.expected = expected;
            this.decryptedString = decryptedString;
        }
        public async override System.Threading.Tasks.Task Invoke(IOwinContext context) {
            await DecryptRequest(context);
            await Next.Invoke(context);
        }
        private async Task DecryptRequest(IOwinContext context) {
            var request = context.Request;
            var requestBody = new StreamReader(request.Body).ReadToEnd();
            Assert.AreEqual(expected, requestBody);
            //Fake decryption code
            if (expected == requestBody) {
                //replace request stream to downstream handlers
                var decryptedContent = new StringContent(decryptedString, Encoding.UTF8, "application/json");
                var requestStream = await decryptedContent.ReadAsStreamAsync();
                request.Body = requestStream;
            }
        }
    }
    public class AnotherCustomMiddleWare : OwinMiddleware {
        private string expected;
        private string responseContent;
        public AnotherCustomMiddleWare(OwinMiddleware next, string expected, string responseContent)
            : base(next) {
            this.expected = expected;
            this.responseContent = responseContent;
        }
        public async override System.Threading.Tasks.Task Invoke(IOwinContext context) {
            var request = context.Request;
            var requestBody = new StreamReader(request.Body).ReadToEnd();
            Assert.AreEqual(expected, requestBody);
            var owinResponse = context.Response;
            // hold on to original stream
            var owinResponseStream = owinResponse.Body;
            //buffer the response stream in order to intercept downstream writes
            var responseBuffer = new MemoryStream();
            owinResponse.Body = responseBuffer;
            await Next.Invoke(context);
            if (expected == requestBody) {
                owinResponse.ContentType = "text/plain";
                owinResponse.StatusCode = (int)HttpStatusCode.OK;
                owinResponse.ReasonPhrase = HttpStatusCode.OK.ToString();
                var customResponseBody = new StringContent(responseContent);
                var customResponseStream = await customResponseBody.ReadAsStreamAsync();
                await customResponseStream.CopyToAsync(owinResponseStream);
                owinResponse.ContentLength = customResponseStream.Length;
                owinResponse.Body = owinResponseStream;
            }
        }
    }
