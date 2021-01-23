        public async Task<IHttpActionResult> DoMyThing(MyObject myObject)
        {
            try
            {                           
                var result = await _myService.CreateMyThingAsync(myObject);
                return new JsonStreamHttpActionResult<MyObject>(Request, System.Net.HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error(ex);
                return new HttpActionResult(HttpStatusCode.InternalServerError, "An error has occured");
            }
        }
