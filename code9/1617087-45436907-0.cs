    public ActionResult Index()
    {
        List<SelectListItem> liprojsList = (from p in db.Projets
                       join uip in db.UtilisateurInProjets on p.ProjetId equals uip.ProjetId
                       where uip.UtilisateurId == 156
                       select new SelectListItem { Value = p.Libelle.Id.ToString(), Text = p.Libelle.Name }).ToList();
        
        ViewBag.liprojs = liprojsList;
        
        return View();
    }
