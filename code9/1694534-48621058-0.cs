    public ActionResult Index(int? page, string SortColumn, string CurrentSort, String SearchText)
    {
        var customer = from s in db.Customers
                       select s;
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        ViewBag.CurrentPage = pageNumber;
        SortColumn = String.IsNullOrEmpty(SortColumn) ? "CompanyName" : SortColumn;
        ViewBag.CurrentSort = SortColumn;
        ViewBag.OldSort = CurrentSort;
        ViewBag.SearchText = SearchText;
        if (!String.IsNullOrEmpty(SearchText))
        {
            customer = customer.Where(s => s.CompanyName.ToUpper().Contains(SearchText.ToUpper())
            || s.ContactName.ToUpper().Contains(SearchText.ToUpper())
            || s.ContactTitle.ToUpper().Contains(SearchText.ToUpper())
            || s.Address.ToUpper().Contains(SearchText.ToUpper()));
        }
        switch (SortColumn)
        {
            case "CompanyName":
                if (SortColumn.Equals(CurrentSort))
                {
                    customer = customer.OrderByDescending(m => m.CompanyName); 
                    ViewBag.CurrentSort = "";
                }
                else
                    customer = customer.OrderBy(m => m.CompanyName); 
                break;
            case "ContactName":
                if (SortColumn.Equals(CurrentSort))
                {
                    customer = db.Customers.OrderByDescending(m => m.ContactName);
                    ViewBag.CurrentSort = "";
                }
                else
                    customer = db.Customers.OrderBy(m => m.ContactName); 
                break;
            case "ContactTitle":
                if (SortColumn.Equals(CurrentSort))
                {
                    customer = db.Customers.OrderByDescending(m => m.ContactTitle); 
                    ViewBag.CurrentSort = "";
                }
                else
                    customer = db.Customers.OrderBy(m => m.ContactTitle); 
                break;
            case "Address":
                if (SortColumn.Equals(CurrentSort))
                {
                    customer = db.Customers.OrderByDescending(m => m.Address); 
                    ViewBag.CurrentSort = "";
                }
                else
                    customer = db.Customers.OrderBy(m => m.Address); 
                break;
            case "Default":
                customer = db.Customers.OrderBy(m => m.CompanyName); 
                break;
        }
        return View(customer.ToPagedList(pageNumber, pageSize));
    }
