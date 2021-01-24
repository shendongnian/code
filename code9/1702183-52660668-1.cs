        [EnableQuery]
        public IActionResult Get()
        {
            // the type of _db.YourModel is not of type YourModel in the Edm model
            return Ok(_db.YourModel);
        }
