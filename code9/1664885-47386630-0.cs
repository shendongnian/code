    // GET: InvoiceHeaders
    public async Task<IActionResult> Index()
    {
        ApplicationUser appUser = ConstantData.GetApplicationUser(_context, _userManager.GetUserId(User));
        var applicationDbContext = _context.InvoiceHeader.Where(i => i.CustomerID == appUser.CustomerID).Aggregate(new InvoiceHeaderModel(),(invoiceHeaderModel, it)=> new InvoiceHeaderModel(){ InvoiceHeader =i,TotalAmount  = i.InvoiceLine.Sum(t=>t.LineAmount)   });
        return View(await applicationDbContext.ToListAsync());
    }
