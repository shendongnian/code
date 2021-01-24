    DataTable dt = new DataTable();
    dt.Columns.Add("id");
    dt.Columns.Add("value");
    dt.Rows.Add("1", "hi");
    string json = new JObject(
        dt.Columns.Cast<DataColumn>()
          .Select(c => new JProperty(c.ColumnName, JToken.FromObject(dt.Rows[0][c])))
    ).ToString(Formatting.None);
    Console.WriteLine(json);
