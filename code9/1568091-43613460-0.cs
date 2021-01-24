    var text = File.ReadAllText("file.txt");
    var jss = new JavaScriptSerializer();
    var root = (Dictionary<string, object>)jss.DeserializeObject(text);
    var data = root.SelectMany(pair => ((object[])pair.Value));
    var dt = new DataTable();
    dt.Columns.Add("special", typeof(bool)).ReadOnly = true;
    // regular
    foreach (var arr in data.OfType<object[]>())
        foreach (Dictionary<string, object> dict in arr)
            foreach (var key in dict.Keys)
                if (!dt.Columns.Contains(key))
                    dt.Columns.Add(key);
    foreach (var arr in data.OfType<object[]>())
        foreach (Dictionary<string, object> dict in arr)
        {
            var row = dt.NewRow();
            foreach (var pair in dict)
                row[dt.Columns[pair.Key]] = pair.Value;
            dt.Rows.Add(row);
        }
    // special
    foreach (var dict in data.OfType<Dictionary<string, object>>())
        foreach (var key in dict.Keys)
            if (!dt.Columns.Contains(key))
                dt.Columns.Add(key);
    foreach (var dict in data.OfType<Dictionary<string, object>>())
    {
        var row = dt.NewRow();
        row["special"] = true;
        foreach (var pair in dict)
            row[dt.Columns[pair.Key]] = pair.Value;
        dt.Rows.Add(row);
    }
    dataGridView.DataSource = dt;
