    public JsonResult SomeMethod(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.UtilisateurInProjet.Where(x=>x.id==id).SelectMany(x=>x.Projects.Select(p=>new { ProjetId=p.ProjetId, Libelle=p.Libelle, UtilisateurInProjet=x.UtilisateurId})).ToList(), JsonRequestBehavior.AllowGet);
    
        }
