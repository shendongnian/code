    [Route("applications/{applicationId}/materials")]
    public class MaterialController
    {
        [HttpGet("{materialId}")]
        public IActionResult Index(string applicationId, string materialId)
        {
            // return your view
        }
    }
