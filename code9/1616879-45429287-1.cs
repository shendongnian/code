    public ActionResult Summary(int quarter, int year)
    {
        SummaryConfigurationVM model = new SummaryConfigurationVM()
        {
            Quarter = quarter,
            Year = year,
            Configurations = floorService.SummaryProc(quarter, year),
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
