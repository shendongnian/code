            // If not found, exit
            if (user == null)
            {
                return HttpNotFound();
            }
    
          
    
                var results = await UserManager.DeleteAsync(user); // Remove user from UserStore
    
                // If the statement is a success
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
