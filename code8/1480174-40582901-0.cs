    public ActionResult SaveService(string ServiceName, decimal cost)
    {
     int result = RankedServices.Business.Provider.ServicesCriteria.SaveService(ServiceName, cost.ToString("0.##"));
      return Json(result, JsonRequestBehavior.AllowGet);
    }
