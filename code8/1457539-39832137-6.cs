    public class FriendsController : ApiController {
        IFacebookService facebook;
        public FriendsController(IFacebookService facebook) {
            this.facebook = facebook;
        }
        [HttpGet]
        public IHttpActionResult GetFacebookFriends() {
            var friends = facebook.GetFriends();
            if(!string.IsNullOrWhiteSpace(friends)) {
                return Ok(friends);
            }
            return NotFound("You have no friends. :(");
        }
    }
