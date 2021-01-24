    List<KeyValuePair<string, string[]>> dicc = dataTable.AsEnumerable()
        .Select(Row => Row["ID"]).Distinct()
        .Select(Id => new KeyValuePair<string, string[]>(
            Id.ToString(),
            dataTable.AsEnumerable()
                .Where(Row => Row["ID"].ToString() == Id.ToString())
                .Select(Row => Row["Date"].ToString())
                .ToArray()))
        .ToList();
