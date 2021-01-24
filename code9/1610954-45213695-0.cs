        [HttpPost]
        [AcceptVerbs("POST", "PUT")]
        public static HttpResponseMessage POST(HttpRequestMessage req)
        {
            try
            {
                //create redis connection and database
                var RedisConnection = RedisConnectionFactory.GetConnection();
                var serializer = new NewtonsoftSerializer();
                var cacheClient = new StackExchangeRedisCacheClient(RedisConnection, serializer);
                //read json object from request body
                var content = req.Content;
                string JsonContent = content.ReadAsStringAsync().Result;
                var expirytime = DateTime.Now.AddHours(Convert.ToInt16(ConfigurationSettings.AppSettings["ExpiresAt"]));
                SessionModel ObjModel = JsonConvert.DeserializeObject<SessionModel>(JsonContent);
                bool added = cacheClient.Add("RedisKey", ObjModel, expirytime); //store to cache 
                return req.CreateResponse(HttpStatusCode.OK, "RedisKey");
            }
            catch (Exception ex)
            {
                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "an error has occured");
            }
        }
    
