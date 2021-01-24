    public JsonResult getSmetkiList()
    {
        List<smetki> datasm = new List<smetki>();
        using (leskaEntities dc = new leskaEntities())
        {
           dc.Configuration.LazyLoadingEnabled = false;
           datasm = dc.smetkis.OrderBy(a => a.smID).ToList();
        }
        return new JsonResult { Data = datasm, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }
