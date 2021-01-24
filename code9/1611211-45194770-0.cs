    for (int i = 0; i < indices.Count; i++)
	{
		DataRow _myRow = dt.NewRow();
		_myRow["Date Time"] = timeList.ElementAt(indices[i]);
		_myRow["CAT Protocol"] = catList.ElementAt(indices[i]);
		_myRow["Display"] = displayList.ElementAt(indices[i]);
		//_myRow["Command ID"] = idList.ElementAt(indices[i]);
		_myRow["Command Description"] = descList.ElementAt(indices[i]);
		dt.Rows.Add(_myRow);
	}
