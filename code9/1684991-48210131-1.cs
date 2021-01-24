    public class UserController : ApiController {
        private readonly IUserServices service;
        public UserController(IUserServices myServices) {
            this.service = myServices;
        }
        public async Task<IHttpActionResult> GetGroupMembers([FromUri]string groupID) {
            IGroupMembersCollectionWithReferencesPage groupMembers = await service.GetGroupMembers(groupID);
            return Ok(groupMembers);
        }
    }
