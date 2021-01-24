    [HttpGet("{ids:" + RouteArrayConstants.NUMBER_ARRAY + "}")]
    [Produces(typeof(TestWebResponseDTO))]
    public async Task<IActionResult> Get([FromRoute, Required]long[] ids)
    {
    }
