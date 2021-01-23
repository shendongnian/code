    public ActionResult MojeKonto()
    {
        Konto konto = null;
        if (User.Identity.IsAuthenticated) {
            using(var db = new AplikacjaContext()) {
                konto = db.MojeKonto.SingleOrDefault(m => m.pesel == User.Identity.Name);
            }
        }
        return View(konto);
    }
