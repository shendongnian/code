    private void GetTotalShareForDay()
    {
        var results = new Dictionary<Tuple<string, string>,List<decimal>>();
        for (var i = 0; i < dgvSummary.Rows.Count; i++)
        {
            string laborerId = dgvSummary.Rows[i].Cells[0].Value.ToString();
            string date = dgvSummary.Rows[i].Cells[1].Value.ToString();
            Tuple<string, string> uniqueKey = new Tuple<string, string>(laborerID, date); // laborerID and date combined provide uniqueness
            decimal share = Convert.ToDecimal(dgvSummary.Rows[i].Cells[5].Value);
            if (!results.ContainsKey(uniqueKey)) 
                results.Add(uniqueKey, new List<double>());
            results[uniqueKey].Add(share);
        }
        foreach(var key in results.Keys)
        {
            // key.Item1 is laborerID
            // key.Item2 is Date as string
            decimal sum = results[key].Sum();
            Console.Write("Laborer ID:" + key.Item1);
            Console.Write("Date:" + key.Item2);
            Console.Write("Sum:" + sum);
        }
    }
