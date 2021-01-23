        [HttpGet("Index",Name = "Index")]
        public IActionResult Index()
        {...
            return new OkObjectResult(some object)
        }
