    public ActionResult Index()
            {
                var db = new PraktikumDataContext();
				
				var model = 
					 (from stud in db.Students
                      select new AdminUserListItem()
                      {
						Name = stud.FH_Angehörige.Name, 
						LastLogin = stud.FH_Angehörige.FE_Nutzer.Letzter_Login, 
						Rolle = "Student"}
					  ).Union(
                      from mit in db.Mitarbeiters
                      select new AdminUserListItem()
                      {
						Name = mit.FH_Angehörige.Name, 
						LastLogin = mit.FH_Angehörige.FE_Nutzer.Letzter_Login, 
						Rolle = "Mitarbeiter"}
					  ).Union(
                      from gast in db.Gasts
                      select new AdminUserListItem()
                      {
						Name = gast.FH_Angehörige.Name, 
						LastLogin = gast.FE_Nutzer.Letzter_Login, 
						Rolle = "Gast"}
					  )
					  .OrderByDescending(a => a.Name)
					  .ToList();
				return View(model);
            }
