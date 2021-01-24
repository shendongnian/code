    public ActionResult Traitement(string designation)
    {
        GabaritRepository gabaritrepository = new GabaritRepository(db);
        var gabarits = gabaritrepository.Get(g => g.Designation == designation)
                                        //Map your Gabarit to your ViewModel here
                                        .Select(x => new GabaritViewModel {
                                            CodeBarre = x.CodeBarre,
                                            Etat = x.Etat
                                        }).ToList();
    
        return View(gabarits);
    }
