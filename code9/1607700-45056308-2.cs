        [HttpGet]
        public async Task<IHttpActionResult> Get(string type) 
        { 
            switch(type)
            {
                case "dog":
                    Dog dog = GetDogDetails();
                    return Ok(dog);
                    break;
    
            ...
            }
        }
