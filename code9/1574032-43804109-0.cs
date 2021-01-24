    public class MembersController : ApiController
        {
        public HttpResponseMessage GetAllMembersByIdentifiers(string[] ids) {
  
     // CHECK THE ARRAY NOT EMPTY
        if(!ids.Any() || ids.All(xx=> string.isNullOrEmpty(xx)) return BadRequest();
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
