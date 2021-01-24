    public ActionResult Create()
        {
            ViewBag.IdDepartement = new SelectList(db.Departement, "IdDepartement", "Description");
            ViewBag.IdEmployeur = new SelectList(db.Employeur, "IdEmployeur", "NomEmployeur");
            ViewBag.IdLocalisation = new SelectList(db.Localisation, "IdLocalisation", "Description");
            ViewBag.IdTelephoneBureau = new SelectList(db.TelephoneBureau, "IdTelephoneBureau", "NumeroInventaire");
            ViewBag.IdTitre = new SelectList(db.TitreEmploye, "IdTitre", "Description");            
            ViewBag.IdSuperviseur = new SelectList(db.Employe.Where(employe => employe.IsSuperviseur.HasValue && employe.IsSuperviseur.Value), "IdEmploye", "NomSuperviseur");
            return View();
        }
