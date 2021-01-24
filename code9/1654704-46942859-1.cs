    public IActionResult Create()
    {
      var vm= new DashboardChartsByMonthModel();
      vm.TimeSliceList = new List<SelectListItem>
      {
            new SelectListItem {Selected = true, Text = "Monthly",
                                                 Value = TimeSlice.ByMonth.ToString()},
            new SelectListItem {Selected = false, Text = "Quarterly",
                                                  Value = TimeSlice.ByQuarter.ToString()}
      };
      return View(vm);
    }
