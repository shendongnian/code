       [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                     throw new 
                    HttpResponseException(HttpStatusCode.UnsupportedMediaType);
             //do your upload functions here
             } catch(Exception e){
             }
         }
