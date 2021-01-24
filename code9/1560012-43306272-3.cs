    [CustomAuthorize] 
    public IActionResult AdminDashboard(){
         if(HttpContext.User.IsInRole("Admin"))
             return View("X");
         else if (HttpContext.User.IsInRole("Guest"))
             return View("Y");
         else 
            return RedirectToAction("Some Action");
            // Or throw an exception 
    }
