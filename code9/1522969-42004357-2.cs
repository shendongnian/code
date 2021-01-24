    public JsonResult GetRaca(string especieId)
    {
        int esp = Convert.ToInt32(especieId);
    
        var result = (from r in db.Raca
            join c in db.RacaConteudo on r.RacaId equals c.RacaId
            where r.EspecieId == esp && c.IdiomaId == 1
            select new {Value = c.RacaId.ToString(), Text = c.NomePopular}).ToList();
        // I believe Text and Value might be opposite in your question. 
        return Json(result, JsonRequestBehavior.AllowGet);
    }
