    private void GetTotalShareForDay()
    {
        var results = new Dictionary<Tuple<string, string>,List<double>>();
        string laborerOrig;
        var date = @"";
        var amount = 0.0;
        for (var i = 0; i < dgvSummary.Rows.Count; i++)
        {
            laborerOrig = dgvSummary.Rows[i].Cells[0].Value.ToString();
            date = dgvSummary.Rows[i].Cells[1].Value.ToString();
            Tuple<string, string> uniqueKey = new Tuple<string, string>(laborerOrig, date);
            share = Convert.ToDouble( dgvSummary.Rows[i].Cells[5].Value);
            if (!results.ContainsKey(uniqueKey)) 
                results.Add(uniqueKey, new List<double>());
            results[uniqueKey].Add(share);
        }
        foreach(var key in results.Keys)
        {
            // key.Item1 is laborerID
            // key.Item2 is Date as string
            var sum = results[key].Sum();
        }
    }
