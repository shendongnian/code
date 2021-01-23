    public FooController : JsonApiController<Foo> {
        private readonly IQueryAccessor _queryAccessor;
        public FooController(IQueryAccessor queryAccessor, /* ... */) 
        : base(/* ... */) {
           _queryAccessor = queryAccessor;
        }
        
        [HttpGet]
        public override async Task<IActionResult> GetAsync() {
            var status = _queryAccessor.GetRequired<string>("status");
            // ...
        }
    }
