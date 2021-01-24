    configuration.AddApiVersioning(o => o.ReportApiVersions = true);
    namespace Master.Infrastructure.Api.Controllers
    {
        [Authorize]
        [ApiVersion("1.0")]
        [RoutePrefix("api/Saved")]
        public class SavedController : ApiController
        {
           private readonly IUserService _userService;
           public SavedController(IUserService userService) => _userService = userService;
           [HttpGet]
           [Route("GetNumberOfSavedWorkouts")]
           public async Task<IHttpActionResult> GetNumberOfSavedWorkouts()
           {
                var userId = User.Identity.GetUserId();
                var count = await _userService.GetNumberOfSavedWorkoutsForUserAsync(userId);
                return Ok(new NumberOfSavedWorkouts(){ CurrentNumberOfSavedWorkouts = count });
           }
        }
    }
    namespace Master.Infrastructure.Api.V2.Controllers
    {
        [Authorize]
        [ApiVersion("2.0")]
        [RoutePrefix("api/Saved")]
        public class SavedController : ApiController
        {
           private readonly ISavedWorkoutService _savedWorkoutService;
           public SavedController(ISavedWorkoutService savedWorkoutService) => _savedWorkoutService = savedWorkoutService;
           [HttpGet]
           [Route("GetNumberOfSavedWorkoutsForUser")]
           public async Task<IHttpActionResult> GetNumberOfSavedWorkoutsForUser()
           {
                var userId = User.Identity.GetUserId();
                var count = await _savedWorkoutService.CountNumberOfSavedWorkoutsForUser(userId);
                return Ok(count);
           }
        }
    }
