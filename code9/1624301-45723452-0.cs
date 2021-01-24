    Users ThisUser = Users.UsersGetByEmail((string)Session["email"]);
    if( ThisUser != null && Crypto.VerifyHashedPassword(ThisUser.PassWord, userInputPassword) ) {
        Session["user_id"] = ThisUser.Id;
        return RedirectToAction("Promise");
    }
    else {
        ModelState.AddModelError("PassWord","Your username or password are incorrect");
        return View(user);
    }
