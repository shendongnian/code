    public class EnvironmentController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        public EnvironmentController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        [HttpGet("routes", Name = "ApiEnvironmentGetAllRoutes")]
        [Produces(typeof(ListResult<RouteModel>))]
        public IActionResult GetAllRoutes()
        {
            var result = new ListResult<RouteModel>();
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                ad => ad.AttributeRouteInfo != null).Select(ad => new RouteModel
                {
                    Name = ad.AttributeRouteInfo.Name,
                    Template = ad.AttributeRouteInfo.Template
                }).ToList();
            if (routes != null && routes.Any())
            {
                result.Items = routes;
                result.Success = true;
            }
            return Ok(result);
        }
    }
