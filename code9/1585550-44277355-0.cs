    [HttpPost]
    
        public async Task<ActionResult> Delete(string Userid, string role)
        {
            // Check for for both ID and Role and exit if not found
            if (Userid == null || role == null)
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
    
                // If successful
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
