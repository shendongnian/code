    public JsonResult GetRaca(string especieId)
    {
        int esp = Convert.ToInt32(especieId);
    
        var result = (from c in db.RacaConteudo
            where c.Raca.EspecieId == esp && c.IdiomaId == 1
            select new {Text = c.NomePopular, Value = c.RacaId.ToString()}).ToList();    
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
