    public JsonResult GetRaca(string especieId)
    {
        int esp = Convert.ToInt32(especieId);
    
        var result = (from r in db.Raca
            join c in db.RacaConteudo on r.RacaId equals c.RacaId
            where r.EspecieId == esp && c.IdiomaId == 1
            select new {Text = c.RacaId.ToString(), Value = c.NomePopular}).ToList();
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
