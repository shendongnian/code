    private static void Test()
    {
        TRoot root = new TRoot() { Client = "ABC", Deals = new List<TDeal>() };
        root.Deals.Add(new TDeal
        {
            DealName = "59045599",
            TShape = new List<TInterval>()
        {
            new TInterval { StartDate = DateTime.Today.ToString(), EndDate = DateTime.Today.AddDays(2).ToString(), Volume = "100" },
            new TInterval { StartDate = DateTime.Today.ToString(), EndDate = DateTime.Today.AddDays(2).ToString(), Volume = "200" }
        }
        });
    
        using (var w = new ChoCSVWriter("nestedObjects.csv").WithFirstLineHeader())
        {
            w.Write(root.Deals.SelectMany(d => d.TShape.Select(s => new { ClientName = root.Client, DealNo = d.DealName, StartDate = s.StartDate, EndDate = s.EndDate, Volume = s.Volume })));
        }
    
    }
