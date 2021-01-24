     public IHttpActionResult Post(string userID, string password)
     {
         if (_userRepository.Exists(userID))
             return BadRequest($"User with ID {userID} already exists");
         _userRepository.Create(userID, password);
         return StatusCode(HttpStatusCode.Created) // or CreatedAtRoute
     }
