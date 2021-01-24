    [RoutePrifix("api/something")]
    public Class blabla : Controller
    {
        [HttpGet("test-{id}")]
        public Task<T> method1{}
    
        [HttpGet("test-something-{id}")]
        public Task<T> method1{}
    }
