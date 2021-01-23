    namespace WebAPI.Controllers
    {
        /// <summary>
        /// summary comment here
        /// </summary>
        /// <remarks>
        /// remark comment here
        /// </remarks>
        [EnableCors("<YourCorsPloicyName>")]
        [Authorize(Policy = "AuthorizationPolicy")]
        [Route("api/[controller]")]
        public class AbcController : Controller
        {
		     //Your class code goes here...
	    }
    }
