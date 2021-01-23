    public ActionResult Login(...) {
        //check if the login is correct, if yes
       using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "MFAD"))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, User.Identity.Name);
                firstName = user.GivenName;
                lastName = user.Surname;
                HttpContext.Current.Session["currentUser"] = firstName + " " + lastName;
            }
