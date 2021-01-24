    [Route("coreapi/control")]
    public class Control : Controller
    {
        [HttpPost(userGroups/{groupId}/users/{userId}/add)]
        public int AddRecord(UserRecord record){
            //This even populates the UserId and GroupId fields in record from     the route
        }
    }
