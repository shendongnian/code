    public static class ErrorMessageFormatter {
        public static IAppBuilder UseCommonErrorResponse(this IAppBuilder app) {
            app.Use<JsonErrorFormatter>();
            return app;
        }
        public class JsonErrorFormatter : OwinMiddleware {
            public JsonErrorFormatter(OwinMiddleware next)
                : base(next) {
            }
            public override async Task Invoke(IOwinContext context) {
                var owinRequest = context.Request;
                var owinResponse = context.Response;
                //buffer the response stream for later
                var owinResponseStream = owinResponse.Body;
                //buffer the response stream in order to intercept downstream writes
                using (var responseBuffer = new MemoryStream()) {
                    //assign the buffer to the resonse body
                    owinResponse.Body = responseBuffer;
                    await Next.Invoke(context);
                    //reset body
                    owinResponse.Body = owinResponseStream;
                    if (responseBuffer.CanSeek && responseBuffer.Length > 0 && responseBuffer.Position > 0) {
                        //reset buffer to read its content
                        responseBuffer.Seek(0, SeekOrigin.Begin);
                    }
                    if (!IsSuccessStatusCode(owinResponse.StatusCode) && responseBuffer.Length > 0) {
                        //NOTE: perform your own content negotiation if desired but for this, using JSON
                        var body = await CreateCommonApiResponse(owinResponse, responseBuffer);
                        var content = JsonConvert.SerializeObject(body);
                        var mediaType = MediaTypeHeaderValue.Parse(owinResponse.ContentType);
                        using (var customResponseBody = new StringContent(content, Encoding.UTF8, mediaType.MediaType)) {
                            var customResponseStream = await customResponseBody.ReadAsStreamAsync();
                            await customResponseStream.CopyToAsync(owinResponseStream, (int)customResponseStream.Length, owinRequest.CallCancelled);
                            owinResponse.ContentLength = customResponseStream.Length;
                        }
                    } else {
                        //copy buffer to response stream this will push it down to client
                        await responseBuffer.CopyToAsync(owinResponseStream, (int)responseBuffer.Length, owinRequest.CallCancelled);
                        owinResponse.ContentLength = responseBuffer.Length;
                    }
                }
            }
            async Task<object> CreateCommonApiResponse(IOwinResponse response, Stream stream) {
                var json = await new StreamReader(stream).ReadToEndAsync();
                var statusCode = ((HttpStatusCode)response.StatusCode).ToString();
                var responseReason = response.ReasonPhrase ?? statusCode;
                //Is this a HttpError
                var httpError = JsonConvert.DeserializeObject<HttpError>(json);
                if (httpError != null) {
                    return new {
                        error = httpError.Message ?? responseReason,
                        error_description = (object)httpError.MessageDetail
                        ?? (object)httpError.ModelState
                        ?? (object)httpError.ExceptionMessage
                    };
                }
                //Is this an OAuth Error
                var oAuthError = Newtonsoft.Json.Linq.JObject.Parse(json);
                if (oAuthError["error"] != null && oAuthError["error_description"] != null) {
                    dynamic obj = oAuthError;
                    return new {
                        error = (string)obj.error,
                        error_description = (object)obj.error_description
                    };
                }
                //Is this some other unknown error (Just wrap in common model)
                var error = JsonConvert.DeserializeObject(json);
                return new {
                    error = responseReason,
                    error_description = error
                };
            }
            bool IsSuccessStatusCode(int statusCode) {
                return statusCode >= 200 && statusCode <= 299;
            }
        }
    }
