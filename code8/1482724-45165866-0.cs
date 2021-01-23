    using Swashbuckle.Swagger.Annotations;
    namespace MyCorp.WebApi.Controllers
    {
      [Authorize]
      public class CrazyObjectController : ODataController
      {
        private MyDbModel db = new MyDbModel();
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(CrazyObject))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid Request")]
        [Authorize(Roles = "AdminAccess")]
        public async Task<IHttpActionResult> Post(CrazyObject crazObj)
        {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                db.CrazyObjects.Add(crazObj);
                await db.SaveChangesAsync();
                return Created(crazObj);
            }
      }
    }
