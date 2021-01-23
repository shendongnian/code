        using System.DirectoryServices.AccountManagement;
        public ActionResult Index()
        {
            UserPrincipal userPrincipal = UserPrincipal.Current;
            String name = userPrincipal.DisplayName; //LastName, FirstName
            return View();
        }
