    String json = JsonConvert.SerializeObject(v);
=>
    public JsonResult ObDo(string urllink)
    {
        string newurl = urllink.Replace("Https://", "").Replace("http://", "").Replace("/*", "");
        var v = new
        {
            domain = db.Identifiers.Where(c => c.domain.Contains(newurl)).First().ID
        };
        //String json = JsonConvert.SerializeObject(v);
        return Json(v, JsonRequestBehavior.AllowGet);
    }
