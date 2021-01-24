    [HttpGet, Route("api/test/{searchString}")] // previous route [HttpGet, Route("api/testelements/{searchString}")]
        public IEnumerable<TestElement> Get(string searchString)
        {
            return Array.FindAll(testelements, s => s.name.Contains(searchString));
        }
