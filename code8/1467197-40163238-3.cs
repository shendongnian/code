    public ActionResult Index()
    {
        UserManageViewModel model = new UserManageViewModel();
        model.users = new List<UsersClass>();
        return View(model);
    }
    
    [HttpPost]
        public ActionResult AddUser(UserManageViewModel model)
        {
            if (model.users.IsEmpty())
            {
                int a = 123;
                model.users = new List<UsersClass>();
            }
            Random generator = new Random();
    
            string[] vez_nevek = new string[10] { "Kovács", "Szekeres", "Király", "Szabó", "Vicha", "Kozma", "Ferencz", "Pócsi", "Tinka", "Horváth" };
            string[] ker_nevek = new string[10] { "Lajos", "Barnabás", "Róbert", "Balázs", "János", "Béla", "Petra", "Anna", "Ferenc", "Attila" };
    
            string vezetek_nev = vez_nevek[generator.Next(vez_nevek.Length)];
            string kereszt_nev = ker_nevek[generator.Next(ker_nevek.Length)];
    
            model.users.Add(new UsersClass(generator.Next(100000, 999999), vezetek_nev + " " + kereszt_nev)); 
    
            return View(model);
        }
