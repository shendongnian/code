     public class MembersController : ApiController
     {
         [HttpGet]
         [Route("api/Members/Find/{ids}")]
         public HttpResponseMessage FindMemebers([FromUri]string[] ids) {
            // CHECK THE ARRAY NOT EMPTY
            if(!ids.Any() || ids.All(xx=> string.isNullOrEmpty(xx))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "empty params");
    
            using (sampleEntities entities = new sampleEntities()){
                var numbers = entities.tblmembers
                    .Where(p => ids.Contains(p.identify)  ).ToList();
        
                if (numbers != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, numbers);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Member with id: " + ids + " not found");
                }
             }
         }
     }
