    [Route("api/[controller]/[action]")]
    public class DistrictController : ControllerBase
    {
    
        [Route("{id:int:min(1)}")] // i.e. GET /api/District/GetDetails/10
        public IActionResult GetDetails(int id)
        {
        }
    
        // i.e. GET /api/District/GetPage/?id=10
        public IActionResult GetPage(int page)
        {
        }
    
        [HttpDelete]
        [Route("{id:int:min(1)}")] // i.e. Delete /api/District/Delete/10
        public IActionResult Delete(int id)
        {
        }
    
        [HttpGet]
        [Route("~/api/States/GetAllState")] // i.e. GET /api/States/GetAllState
        public IActionResult GetStates()
        {
        }
    }
