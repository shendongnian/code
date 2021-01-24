    // GET: InvoiceHeaders
    public async Task<IActionResult> Index()
    {
        ApplicationUser appUser = ConstantData.GetApplicationUser(_context, _userManager.GetUserId(User));
        var applicationDbContext =await _context.InvoiceHeader.Where(i =>i.CustomerID == appUser.CustomerID).ToListAsync();
        var data = applicationDbContext.Aggregate( new List<InvoiceHeaderModel>(),(invoiceHeaderModellist, it)=>{ invoiceHeaderModellist.Add(new InvoiceHeaderModel(){ InvoiceHeader =it,TotalAmount  = it.InvoiceLine.Sum(t=>t.LineAmount)}); return invoiceHeaderModellist;});
        return View(data);
    }
