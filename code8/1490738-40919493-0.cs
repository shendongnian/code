	static void Main(string[] args)
	{
		DataTable dt = new DataTable();
		string path = "test_data.csv";
		bool isFirstRowHeader = true;
		dt = Utils.GetDataTableFromCsv(path, isFirstRowHeader);
		var results = from row in dt.AsEnumerable()
					  group row by row.Field<string>("Group") into grp
					  let dr = dt.NewRow()
					  where (dr.ItemArray = new object[] { grp.Key, grp.Sum(r => r.Field<int>("Value")) }) != null
					  select dr ;
		DataTable newDataTbl = results.CopyToDataTable();
	}
