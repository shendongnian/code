    public IHttpActionResult Put(User user) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        var count = _userService.InsertOrUpdateUser(user);
        if(count == 1)
            return Ok(user);
        else
            return BadRequest(); // 500 (Internal Server Error) you choose. 
    }
