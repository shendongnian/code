    var user = context.Users.Where(u => u.Flag = true).FirstOrDefault();
    ViewBag.IsEnabled = user != null && user.Flag;
    // Pointless because you are getting the one with True;
    // So the value will be always true if user is not null
    return View();
