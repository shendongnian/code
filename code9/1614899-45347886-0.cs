    public JsonResult GetProjsName(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;
        List<Projet> liprojs = db.Projets.Join(db.UtilisateurInProjet,projet=>  projet.ProjetId,utilisateurInProjet => utilisateurInProjet.ProjetId,(projet,utilisateurInProjet) => new {projet.ProjetId, projet.Libelle, utilisateurInProjet.UtilisateurId} ).Where(utilisateurInProjet.UtilisateurId==id).ToList();
        return Json(liprojs, JsonRequestBehavior.AllowGet);
    }
