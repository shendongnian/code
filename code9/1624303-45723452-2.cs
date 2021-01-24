    //Why are you storing "email" in Session before user is validated??? Seems off.
    Users ThisUser = Users.UsersGetByEmail((string)Session["email"]);
    string userInputPassword = user.PassWord; //this should be coming from POST
    if( ThisUser != null && Crypto.VerifyHashedPassword(ThisUser.PassWord, userInputPassword) ) {
        Session["user_id"] = ThisUser.Id;
        return RedirectToAction("Promise");
    }
    else {
        ModelState.AddModelError("PassWord","Your username or password are incorrect");
        return View(user);
    }
