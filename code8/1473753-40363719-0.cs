    private readonly IEnumerable<Country> _countries;
    public IEnumerable<SelectListItem> Countries
    {
        get
        {
            return _countries.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
        }
    }
