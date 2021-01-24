    public ActionResult Index()
    {
        var users = _context.Users.ToList();
        var bills = _context.Bills.ToList();
        var viewModel = new UserBills
        {
            Users = users.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.UserName.ToString() }),
            Bills = bills
        }
    
        return View(viewModel);    
    }
