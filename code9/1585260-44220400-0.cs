    [Route("api/groups/{groupId}/[controller]")]
    public class AttendancesController : Controller {
        public AttendancesController(IGroupService groupService, IAttendanceService attendanceService, IPersonService personService, IPersonAttendanceService personAttendanceService) {
            //
        }
    
     
        [HttpGet] // Matches GET api/groups/1/attendances
        public IActionResult GetAttendancesForGroup(int groupId) {
            //
        }
    
    
        [HttpGet("{date:datetime}")] //Matches GET api/groups/1/attendances/2017-05-27
        public IActionResult GetAttendanceForGroup(int groupId,  DateTime date) {
            //
        }
    
        [HttpPost] // Matches POST api/groups/1/attendances
        public IActionResult CreateAttendanceForGroup(int groupId, [FromBody] AttendanceCreateDto dto) {
            //
        }
    
    
        [HttpGet("~/api/people/{personId}/[controller]")] // Matches GET api/people/1/attendances
        public IActionResult GetAttendancesForPerson(int personId) {
            //
        }
    
        [HttpDelete("{id:int}")] // Matches DELETE api/groups/1/attendances/10
        public IActionResult Delete(int groupId, int id) {
            var group = _groupService.FindById(groupId);
            if (group == null)
                return NotFound();
            var attendance = _attendanceService.GetAttendanceByIdAndGroupId(id,groupId);
            if (attendance == null)
                return NotFound();
    
            _attendanceService.Delete(attendance);
            return NoContent();
        }
    }
