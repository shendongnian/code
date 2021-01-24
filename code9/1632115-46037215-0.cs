    [HttpGet] 
    public ActionResult Create(int id)
    {
        using (Stamm_Retoure dc = new Stamm_Retoure())
        {
    		var n = dc.HN_Retoure_Stamm.ToList().Select(a => a.Retoure_Nummer).Last();
    		var last = n + 1;
    
    		var retoure = new HN_Retoure_Stamm() { Retoure_Nummer = last };
    
    		return View(retoure);
        }
    }
