    using a = System.Web.Http;
    
    [a.RoutePrefix("Hello/Jan")] //RoutePrefix used to group common route on controller
    public MyController : ApiController {
        //...other code removed for brevity. ie: pro    
        //GET Hello/Jan
        [a.HttpGet]
        [a.Route("")]
        public IHttpActionResult GetDepartmets() {
            var departments = pro.GetDept().ToList();
            return Ok(departments);
        }
        
        //GET Hello/Jan/1
        [a.HttpGet]
        [a.Route("{id:int}")] //Already have a default route. No need to make this optional
        public IHttpActionResult GetDepartmet(int id) {
             var department = pro.GetDeptById(id);
             if (department != null) {
                 return Ok(department);
             }
    
             return NotFound();    
        }
    }
