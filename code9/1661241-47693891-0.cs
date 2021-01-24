    [HttpPost]
        public HttpResponseMessage Default()
        {
            try
            {
                NameValueCollection collection = Request.Content.IsFormData() ?
                    Request.Content.ReadAsFormDataAsync().Result :
                    GetCollection(Request.Content.ReadAsAsync<IDictionary<string, object>>().Result);
                var parameters = ServiceAgentParameters.From(collection);
                var agent = new ScriptingAgentClient();
                var response = agent.Run(parameters);
                if (response.Error)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { ErrorMessage = response.ErrorMessage, Exception = response.Exception });
                if (response.Data != null && response.Data.Count == 1) //result.Data is List<byte[]>
                {
                   //TODO: use the right Serializer
                var resultString = Encoding.UTF8.GetString(result.Data[0]);
                var serializer = new JavaScriptSerializer();
                var dict = serializer.Deserialize<Dictionary<string, string>>(resultString);
                return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { ErrorMessage = "Unknown error" });
            }
            catch (Exception ex)
            {
                Logger.Error("Error handling request", ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Unwrap().Message });
            }
        }
