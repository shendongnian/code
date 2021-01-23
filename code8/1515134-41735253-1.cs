    private void GetTotalShareForDay()
    {
        var results = new Dictionary<string,List<double>>();
        string laborerId;
        var date = @"";
        var amount = 0.0;
        for (var i = 0; i < dgvSummary.Rows.Count; i++)
        {
            laborerId = dgvSummary.Rows[i].Cells[0].Value.ToString();
            date = dgvSummary.Rows[i].Cells[1].Value.ToString();
            string uniqueKey = laboredId + ","  + date;
            share = Convert.ToDouble( dgvSummary.Rows[i].Cells[5].Value);
            if (!results.ContainsKey(uniqueKey)) 
                results.Add(uniqueKey, new List<double>());
            results[uniqueKey].Add(share);
        }
        foreach(var key in results.Keys)
        {
            // key is laborerID + "," + date
            var sum = results[key].Sum();
        }
    }
