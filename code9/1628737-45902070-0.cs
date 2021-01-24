    private void ConfigureViewModel(ReferralViewModel model)
    {
        // Populate companies always
        model.Companies = _context.Companies.Select(x => new SelectListItem
        {
            Text = x.CompanyName,
            Value = x.CompanyId.ToString()
        });
        // Populate cover letters only if a company has been selected
        // i.e. if your editing and existing Referral, or if you return the view in the POST method
        if (model.CompanyId.HasValue)
        {
            model.CoverLetters = _context.CoverLetters.Where(x => x.CompanyId == companyId).Select(x => new SelectListItem
            {
                Value = x.CoverLetterId.ToString(),
                Text = x.CoverLetterName
            });
        }
        else
        {
            model.CoverLetters  = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
    public ActionResult Create()
    {
        ReferralViewModel model = new ReferralViewModel();
        ConfigureViewModel(model);
        return View(model);
    }
    public ActionResult Create(ReferralViewModel model)
    {
        if (!ModelState.IsValid())
        {
            ConfigureViewModel(model);
            return View(model);
        }
        // Initialize data model, map properties from view model, save and redirect
    }
