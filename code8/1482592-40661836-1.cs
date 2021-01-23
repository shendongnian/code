    if (string.IsNullOrEmpty(ROOM))
        {
            return this.Request.CreateResponse(
            HttpStatusCode.BadRequest,
            new { error= "ROOM cannot be empty or NULL" });
            resp.Content.Headers.ContentType = 
               new MediaTypeHeaderValue("application/json");
            return resp;
        }
