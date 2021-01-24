    if (columnsToSelect != null)
    var result = query.Select(s => s.GetType().GetProperty("columnName").GetValue(s, null).ToString())
                .Select(s => new MyTable()
                {
                    YourProperty = s.ToString()
                }).ToList();
