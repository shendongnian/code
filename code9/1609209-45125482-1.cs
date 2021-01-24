    using System.Web.Http.Cors;
    
    namespace xxxAPI.Controllers
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class xxxxController : ApiController
        { //.. blah blah blah
