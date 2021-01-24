    [Route("Department")]
    public class DepartmentController : Controller {
        [HttpPost("Test1/{testId:int}")] //Matches POST Department/Test1/1
        public IActionResult Test1(int testId, [FromBody]DepartmentDTO departmentDto) {
            return Json(departmentDto);
        }
    }
