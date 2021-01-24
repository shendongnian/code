     [Route("rename/{userId}/{type}/{title}" Name = "RenameUser"]
     public IHttpActionResult Rename(int userId, string type, string title)
     {
         _myServiceMethod.Rename(userId, type, title);
         return new StatusCodeResult(HttpStatusCode.Created, this);   
     }
