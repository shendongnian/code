    // GET: InvoiceHeaders
    public async Task<IActionResult> Index()
    {
        ApplicationUser appUser = ConstantData.GetApplicationUser(_context, _userManager.GetUserId(User));
                var applicationDbContext = _context.InvoiceHeader.Include(i => i.Customer).Include(i => i.CustomerBranch)
                    .Where(i => i.CustomerID == appUser.CustomerID)
                    .Select(i => new InvoiceListViewModel
                    {
                        invoiceHeader = i,
                        TotalAmount = i.InvoiceLines.Sum(t => t.LineAmount)
                    });
        return View(await applicationDbContext.ToListAsync());
    }
