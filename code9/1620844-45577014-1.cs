    public Actionresult SelectPlaats()
    {
       var one = repository.GetAllReserveringen.Where(x => x.StartDatum >= x.StartDatum && x.StartDatum <= x.EindDatum); 
       return View(repository.GetAllPlekken.Except(one).ToList());
    }
