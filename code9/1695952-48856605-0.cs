    [Route("api/Upload")]
        [HttpPost]
       // i have tested public async Task<HttpResponseMessage> Upload(string id) <= giving parameters. the api doesnt hit if i give any
        public async Task<HttpResponseMessage> Upload()
        {
            var request = HttpContext.Current.Request;
            var key = Request.Params["key"]; // **<- LOOK AT THIS HERE**
            HttpResponseMessage result = null;    
            if (request.Files.Count == 0)
            {
                result = Request.CreateResponse(HttpStatusCode.OK, "Ok");;
            }
            var postedFile = request.Files[0];
            return Request.CreateResponse(HttpStatusCode.OK, "Ok");
        }
