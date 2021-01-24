    static void Main(string[] args)
    {
        string json = "{\"columns\":[\"firstName\",\"lastName\",\"email\",\"password\",],\"rows\":[[\"Alpha\",\"Tango\",\"AlphaTango@domain.com\",\"123\"],[\"Charle\",\"Tango\",\"CharlieTango@domain.com\",\"456\"]]}";
        dynamic jObject = JObject.Parse(json);
        //Get columns of your object
        List<string> columns = JsonConvert.DeserializeObject<List<string>>(jObject.columns.ToString());
        //Get rows of your object
        List<string[]> rows = JsonConvert.DeserializeObject<List<string[]>>(jObject.rows.ToString());
        using (DataTable dt = new DataTable())
        {
            //Create columns
            foreach (string column in columns)
                dt.Columns.Add(new DataColumn(column));
            //Add rows
            foreach (string[] row in rows)
            {
                int columnOrdinal = 0;
                DataRow newRow = dt.NewRow();
                foreach (string value in row)
                {
                    newRow.SetField<string>(columnOrdinal, value);
                    columnOrdinal++;
                }
                dt.Rows.Add(newRow);
            }
        }
    }
