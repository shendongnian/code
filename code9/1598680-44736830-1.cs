    using Microsoft.AspNetCore.Mvc;
    
    namespace MyApi.Controllers
    {
            [Route("api/[controller]")]
            public class ValuesController : Controller
            {
                    [HttpGet]
                    public ActionResult UploadFile([FromQuery]string file)
                    {
                            return new ObjectResult(new { status = "success = " + file });
                    }
                    [HttpGet]
                    [Route("test")]
                    public string Test() { return "test"; }
            }
    }
