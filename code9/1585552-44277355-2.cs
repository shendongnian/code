    [HttpPost]
    
        public async Task<ActionResult> Delete(string userId)
        {
            // Check for for both ID and exit if not found
            if (String.IsNullEmpty(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }  
            var user = UserManager.Users.SingleOrDefault(u => u.Id == Userid);
