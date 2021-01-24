    public Actionresult SelectPlaats()
    {
       var one = repository.GetAllReserveringen.Where(x => x.StartDatum >= x.StartDatum && x.StartDatum <= x.EindDatum).Select(p => p.Plaats).ToList(); 
       return View(repository.GetAllPlekken.Where(p => !one.Contains(p.plaatsnummer)).ToList());
    }
