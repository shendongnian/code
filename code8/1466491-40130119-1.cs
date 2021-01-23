    var dt = Utilities.ExecuteQueryMysqlString(connectionString, "SELECT name, month_year FROM my_table", null);
    var nameDatePairSet = new HashSet<NameDatePair>(dt.AsEnumerable().Select(
    	r => new NameDatePair(r.Field<string>("name"), r.Field<DateTime>("month_year"))));
    
    for (int index = 0; index < dtSightings.Rows.Count; index++)
    {
    	var dr = dtSightings.Rows[index];
    	var name = dr.Field<string>("name");
    	var billYear = dr.Field<int>("billYear");
    	var billMonth = dr.Field<int>("billMonth");
    	bool exists = nameDatePairSet.Contains(new NameDatePair(name, new DateTime(billYear, billMonth, 1)));
    }
