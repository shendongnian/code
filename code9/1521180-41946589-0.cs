    var dgv = this.configDiffDataGridView;               
    var dict = new Dictionary<string, List<string>>();
    for (int i = 0; i < dgv.RowCount; i++)
    {
        if (true.Equals(dgv[4, i].Value))           // to avoid Exception when Value is not bool
        {
            string key = dgv[0, i].Value as string; // or Value?.ToString() for non-string types
            List<string> list;
            if (!dict.TryGetValue(key, out list))   // if not found, create and add
            {
                list = new List<string>(2);         // adjust capacity to the average # of items
                dict.Add(key, list);
            }
            list.Add(dgv[1, i].Value as string);
        }
    }
