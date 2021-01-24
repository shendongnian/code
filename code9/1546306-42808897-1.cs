    public JsonResult getSmetkiList()
    		{
    			List<smetki> data = new List<smetki>();
    			using (leskaEntities leskaEntities = new leskaEntities())
    			{
    				leskaEntities.Configuration.LazyLoadingEnabled = false;
    				data = (from a in leskaEntities.smetkis
    				orderby a.smID
    				select a).ToList<smetki>();
    			}
    			return new JsonResult
    			{
    				Data = data,
    				JsonRequestBehavior = JsonRequestBehavior.AllowGet
    			};
    		}
