    public PageModel GetChart()
    {
        PageModel R = new PageModel();
        R.Title = "Some Title";
        R.Chart = new List<ChartGroups>(); //< ---
        R.Chart.Add(New ChartGroups { Freq = "Test", Head = "Test2"});
        R.Chart.Add(New ChartGroups { Freq = "Test3", Head = "Test4"});
        return R;
    }
