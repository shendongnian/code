    private void GetTotalShareForDay()
    {
        var results = new Dictionary<string,List<decimal>>();
        for (var i = 0; i < dgvSummary.Rows.Count; i++)
        {
            string laborerId = dgvSummary.Rows[i].Cells[0].Value.ToString();
            string date = dgvSummary.Rows[i].Cells[1].Value.ToString();
            string uniqueKey = laboredId + ","  + date; // Looking at your data, this should provide a unique ID
            decimal share = Convert.ToDecimal(dgvSummary.Rows[i].Cells[5].Value);
            if (!results.ContainsKey(uniqueKey)) 
                results.Add(uniqueKey, new List<decimal>());
            results[uniqueKey].Add(share);
        }
        foreach(var key in results.Keys)
        {
            // key is laborerID + "," + date
            var sum = results[key].Sum();
        }
    }
