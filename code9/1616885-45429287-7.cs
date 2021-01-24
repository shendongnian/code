    public ActionResult Summary(int? quarter, int? year)
    {
        IEnumerable<SummaryConfiguration> configurations = new List<SummaryConfiguration>();
        if (quarter.HasValue && year.HasValue)
        {
            configurations = floorService.SummaryProc(quarter.Value, year.Value);
        }
        SummaryConfigurationVM model = new SummaryConfigurationVM()
        {
            Quarter = quarter,
            Year = year,
            Configurations = configurations,
            QuarterList = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Q1", Value = "1" },
                ....
            },
            YearList = new List<SelectListItem>()
            {
                ....
            }
        };
        return View(model);
    }
