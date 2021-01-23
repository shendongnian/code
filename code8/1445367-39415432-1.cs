        using System.DirectoryServices.AccountManagement;
        public ActionResult Index()
        {
            UserPrincipal userPrincipal = UserPrincipal.Current;
            var name = userPrincipal.GivenName + " " + userPrincipal.Surname;
            return View();
        }
