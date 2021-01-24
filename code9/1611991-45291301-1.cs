	public static DataTable AsDataTable<T>(this IEnumerable<T> rows) {
		var dt = new DataTable();
		var infos = typeof(T).GetProperties();
		foreach (var info in infos)
			dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
		foreach (var r in rows) {
			var nr = dt.NewRow();
			for (int i = 0; i < infos.Length; ++i) {
				nr[i] = infos[i].GetValue(r);
			}
			dt.Rows.Add(nr);
		}
		return dt;
	}
	public static EnumerableRowCollection<DataRow> AsDataRows<T>(this IEnumerable<T> rows) => rows.AsDataTable().AsEnumerable();
