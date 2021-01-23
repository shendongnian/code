    using Microsoft.AspNetCore.Mvc;
    using Service_Layer;
    namespace Address_Book.Controllers
    {
        [Route("api/[controller]")]
        public class PeopleController : Controller
        {
            #region Dependencies:
    
            private readonly IPeopleService peopleService;
    
            #endregion
    
            #region Constructor:
    
            public PeopleController(IPeopleService peopleService)
            {
                this.peopleService = peopleService;
            }
    
            #endregion
    
            [HttpGet]
            public JsonResult Get()
            {
                var branches = peopleService.GetBranches();
                return Json(branches);
            }
    
            [HttpGet("{id}")]
            public JsonResult Get(int id)
            {
                var people = peopleService.GetEmployees(id);
                return Json(people);
            }
        }
    }
