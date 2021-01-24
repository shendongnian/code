	List<string> cells = new List<string>();
	cells.Add("$C$4");
	cells.Add("$D$5");
	cells.Add("$H$10");
	for (int idx = 0; idx < cells.Count; idx++)
		cells[idx] = String.Format("'{0}'!{1}", (excelApp.ActiveSheet as _Excel.Worksheet).Name, cells[idx]);
	string rangeDef = String.Format("={0}", String.Join(";", cells));
	var sheet = (excelApp.ActiveSheet as _Excel.Worksheet).get_Range(rangeDef, Type.Missing).Select();
