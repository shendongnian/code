	[HttpPost]
	[ValidateAntiForgeryToken]
	public PartialViewResult CreateSearch(string searchName, int? page)
	{
		if (string.IsNullOrEmpty(searchName)) return null;
		int number;
		var list = int.TryParse(searchName, out number) 
			? CustomerDataService.SearchCustomerByNumber(number) 
			: CustomerDataService.SearchCustomerByName(searchName);
		var permitsVm = new PermitsViewModel 
			{SearchVm = {Customers = list.ToPagedList(page ?? 1, 20)}};
		ViewBag.SearchName = searchName;
		return PartialView("_PermitsCreateCustomerList", permitsVm);
	}
