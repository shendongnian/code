        public async Task<IHttpActionResult> DoMyThing(MyObject myObject)
        {
            try
            {                           
                var result = DoSomethingElse();
                return new JsonStreamHttpActionResult<MyObject>(Request, result);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error(ex);
                return new HttpActionResult(HttpStatusCode.InternalServerError, "An error has occured");
            }
        }
