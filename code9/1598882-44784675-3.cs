    public MapperTable[] ConvertCsvUsingMap(DataTable csv) {
        var namesFromColumnCsvMap = DataAccess.ExportCsvMaps.FindByExp(x => x.ConfigId == idINt).FirstOrDefault();
        foreach (DataRow row in csv.Rows) {
            var csvMapped = new MapperTable {
                EE_First_Name = csv.Columns.Contains(namesFromColumnCsvMap.EE_First_Name.TrimEnd()) ? row[namesFromColumnCsvMap.EE_First_Name.TrimEnd()].ToString() : "",
                EE_Last_Name = csv.Columns.Contains(namesFromColumnCsvMap.EE_Last_Name.TrimEnd()) ? row[namesFromColumnCsvMap.EE_Last_Name.TrimEnd()].ToString() : "",
                EE_MI = csv.Columns.Contains(namesFromColumnCsvMap.EE_MI.TrimEnd()) ? row[namesFromColumnCsvMap.EE_MI.TrimEnd()].ToString() : "",
            };
            //...
        }
    }
