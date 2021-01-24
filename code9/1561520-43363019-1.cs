    public ActionResult DeleteUser(string id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var user = context.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(context.Users.Find(id));
            }
    
           
            public async Task<ActionResult> UserDeleteConfirmed(string id)
            {
                var user = await UserManager.FindByIdAsync(id);
    
                var result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["UserDeleted"] = "User Successfully Deleted";
                    return RedirectToAction("ManageEditors");
                }
                else
                {
                    TempData["UserDeleted"] = "Error Deleting User";
                    return RedirectToAction("ManageEditors");
                }
            }
