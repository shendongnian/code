        [HttpGet]
        public IHttpActionResult City() //add string city or any input class variable if you're taking any inputs
        {
            return Ok(new List<object>()
            {
                new { id = 1, Name ="asd"},
                new { id = 2, Name ="dsa"}
            }); //This will return a JSON serialized result
        }
