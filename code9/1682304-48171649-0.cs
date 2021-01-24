    public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, int? PageSize)
        
        // Sort order is passed to view in order to keep it intact while clicking in another page link
	    ViewBag.CurrentSort = sortOrder;
        // Ascending or descending sorting by first or last name according to sortOrder value
	    ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
	    ViewBag.FirstNameSortParm = sortOrder == "firstname" ? "firstname_desc" : "firstname";
        // Not sure here
	    if (searchString == null)
	    {
			searchString = currentFilter;
	    }
        // Pass filtering string to view in order to maintain filtering when paging
	    ViewBag.CurrentFilter = searchString;
	    var users = from u in _db.USER select u;
	    // FILTERING
	    if (!String.IsNullOrEmpty(searchString))
	    {
			users = users.Where(u => u.lastname.Contains(searchString)
								  || u.firstname.Contains(searchString)
		}
		// Ascending or descending filtering by first/last name
		switch (sortOrder)
		{
		case "lastname": // Ascending last name
			users = users.OrderBy(u => u.lastname);
			break;
		case "lastname_desc": // Descending last name
			users = users.OrderByDescending(u => u.lastname);
			break;
		case "firstname": // Ascending first name
			users = users.OrderBy(u => u.firstname);
			break;
		case "firstname_desc": // Descending first name
			users = users.OrderByDescending(u => u.firstname);
			break;
		default:
			users = users.OrderBy(u => u.lastname);
			break;
	}
	// DROPDOWNLIST FOR UPDATING PAGE SIZE
	int count = _db.USER.OrderBy(e => e.Id).Count(); // Total number of elements
    // Populate DropDownList
	ViewBag.PageSize = new List<SelectListItem>() {
		new SelectListItem { Text = "10", Value = "10", Selected = true },
		new SelectListItem { Text = "25", Value = "25" },
		new SelectListItem { Text = "50", Value = "50" },
		new SelectListItem { Text = "100", Value = "100" },
		new SelectListItem { Text = "All", Value = count.ToString() }
	};
	int pageNumber = (page ?? 1);
	int pageSize = (PageSize ?? 10);
	ViewBag.psize = pageSize;
		
	return View(users.ToPagedList(pageNumber, pageSize));
    }
