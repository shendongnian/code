        [Route("monitor")]
        public class MonitorController : Controller {
            private readonly IActionDescriptorCollectionProvider _provider;
        
            public MonitorController(IActionDescriptorCollectionProvider provider) {
              _provider = provider;
            }
        
            [HttpGet("routes")]
            public IActionResult GetRoutes() {
                var routes = _provider.ActionDescriptors.Items.Select(x => new { 
                   Action = x.RouteValues["Action"], 
                   Controller = x.RouteValues["Controller"], 
                   Name = x.AttributeRouteInfo.Name, 
                   Template = x.AttributeRouteInfo.Template 
                }).ToList();
                return Ok(routes);
            }
          }
