	var data = new JavaScriptSerializer().Deserialize<List<UserActivityData>>(File.ReadAllText(@"C:\users\foo\desktop\demo.json")); //saved your data locally
	data.Where(x => x.EventType == "5") // 5 is KeyPress
		.GroupBy(d => d.ProcessName) //Grouping by ProcessName
		.Select (d => new {
			ProcessName = d.FirstOrDefault().ProcessName,
            //get Max; substract min; get rough duration in seconds
			Duration = d.Max (x => x.EventTime) - d.Min (x => x.EventTime), 
            //sum up all ticks to get duration in ticks
			DurationTicks = d.Sum (x => x.LongEventTime)
		})
        //LinqPad native; do not use in Visual Studio or VS Code
		.Dump();
