	[HttpPost]
	[ValidateAntiForgeryToken]
	public PartialViewResult CreateSearch(PermitsViewModel permitsVm)
	{
		if (string.IsNullOrEmpty(permitsVm.SearchVm.SearchCustomerNameNumber)) return null;
		int number;
		var list = int.TryParse(permitsVm.SearchVm.SearchCustomerNameNumber, out number) 
			? CustomerDataService.SearchCustomerByNumber(number) 
			: CustomerDataService.SearchCustomerByName(permitsVm.SearchVm.SearchCustomerNameNumber);
		permitsVm.SearchVm.Customers = list.ToPagedList(permitsVm.Page ?? 1, 10);
		return PartialView("_PermitsCreateCustomerList", permitsVm);
	}
