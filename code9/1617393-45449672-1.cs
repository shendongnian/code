    [Route("api/campus")]
    public class BuildingController : Controller
    {
       [HttpGet]
       [Route("{campusId}/building/{buildingId}")]
       public IActionResult GetBuilding (BuildingIdInput input) 
       { 
          if (ModelState.IsValid) 
          {...}
       }
    }
