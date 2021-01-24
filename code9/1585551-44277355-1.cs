    [HttpPost]
    
        public async Task<ActionResult> Delete(string userId)
        {
            // Check for for both ID and exit if not found
            if (String.IsNullEmpty(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
    
            
            var user = UserManager.Users.SingleOrDefault(u => u.Id == Userid);// Look for user in the UserStore
    
            // If not found, exit
            if (user == null)
            {
                return HttpNotFound();
            }
    
          
    
                var results = await UserManager.DeleteAsync(user); // Remove user from UserStore
    
                // If the statement is success
                if (results.Succeeded)
                {
                    // Redirect to Users page
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
        
    
        }
