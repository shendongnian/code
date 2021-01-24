	public ActionResult ExportCvPdf()
	{
		string switches = string.Format("--disable-smart-shrinking --header-html {0} --footer-html {1}",
         Url.Action("Header", "Cotroller", new { area = "Areaname" }, "http"),
         Url.Action("Footer", "Cotroller", new { area = "Areaname" }, "http"));
        return new Rotativa.ViewAsPdf("Preview", data)
          {
            FileName = "Sample-" + DateTime.Now.ToString("yyyyMMdd") + ".pdf",
            PageSize = Size.A4,
            PageMargins = new Margins(30, 15, 20, 15),
            CustomSwitches = switches
          };
		  
	}
	public ActionResult Preview(ViewModel detail)
    {
      return View(detail);
    }
