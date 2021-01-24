    [Route("models")]
    public class ModelsController : Controller
    {
        [HttpGet]
        [Route("{ids}")]
        [Produces(typeof(IEnumerable<Model>))]
        public IActionResult Get
        (
            [ModelBinder(typeof(CsvModelBinder<string>))] IEnumerable<string> ids
        )
        {
            // Get models
            return Ok(models);
        }
    }
