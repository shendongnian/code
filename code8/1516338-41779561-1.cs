    public ActionResult UserPerMonth()
    {
        var _con = new DBEntities();
        ArrayList xValue = new ArrayList();
        ArrayList yValue = new ArrayList();
        var results = (from c in _con.Users select c);
   
        var axis = results.GroupBy(r => r.date.Value.ToString("MMM-yyyy"))
                .Select(n => new ChartData
                {
                    Month = r.Key,
                    Count = r.Count()
                }).ToList();
        foreach (var item in axis)
        {
            xValue.Add(item.Month);
            yValue.Add(item.Count);
        }
        var chart = new Chart(width: 300, height: 200)
            .AddTitle("Users per month")
            .AddLegend()
            .AddSeries(
                chartType: "Column",
                xValue: xValue,
                yValues: yValue)
            .GetBytes("png");
        return File(chart, "image/png");
    }
