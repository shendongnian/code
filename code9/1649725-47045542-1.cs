    //[ChildActionOnly]
            [ActionName("_Dodatki")]
            public ActionResult Dodatki()
            {
                using (var context = new DluzynaContext())
                {
                    var lista = context.Indeks.Select(it => it.Dzien).ToList();
    
                    return PartialView("_Dodatki", lista);
                }
            }
