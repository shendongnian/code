    [HttpPost]
    public ActionResult Results(Date1? objdate1)
    {
	var DataContext = new BalanceDataContext();
	
	if (!objdate1.HasValue){
		objdate1 = new Date1();
		objdate1.DateStart = DateTime.Now;
	}
	
	DateTime earliestDate = objdate1.DateStart.Value.AddMonths(-13);
	//Exact same Code omitted Here ---------------------------
	ViewBag.Metric = 1;
	ViewBag.Message = objdate1.DateStart.Value.ToString("yyyy-MMMM-dd");
	ViewBag.Title2 = "% of Electric Estimated";
	ViewBag.Descript = "Percentage of estimated electric bills per Month.";
	return View(new QueryView { Date2 = totalbills, Date1 = totalEstimated });
}
