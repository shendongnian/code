    public MapperTableConvertCsvUsingMap(DataTable csv) {
        var namesFromColumnCsvMap = DataAccess.ExportCsvMaps.FindByExp(x => x.ConfigId == idINt).FirstOrDefault();
        foreach (DataRow row in csv.Rows) {
            var csvMapped = new MapperTable {
                EE_First_Name = csv.Columns.Contains(namesFromColumnCsvMap.EE_First_Name__.TrimEnd()) ? row[namesFromColumnCsvMap.EE_First_Name__.TrimEnd()].ToString() : "",
                EE_Last_Name__ = csv.Columns.Contains(namesFromColumnCsvMap.EE_Last_Name__.TrimEnd()) ? row[namesFromColumnCsvMap.EE_Last_Name__.TrimEnd()].ToString() : "",
                EE_MI = csv.Columns.Contains(namesFromColumnCsvMap.EE_MI.TrimEnd()) ? row[namesFromColumnCsvMap.EE_MI.TrimEnd()].ToString() : "",
            };
            //...
        }
    }
