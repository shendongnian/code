    public IEnumerable<SelectListItem> SelectListRegions
    {
        get
        {
            return Regions.Select(x => new SelectListItem
            {
                Text = x.Display,
                Value = x.Value.ToString()
            });
        }
    }
