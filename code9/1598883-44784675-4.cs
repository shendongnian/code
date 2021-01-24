    public MapperTable[] ConvertCsvUsingMap(DataTable csv) {
        var namesFromColumnCsvMap = DataAccess.ExportCsvMaps.FindByExp(x => x.ConfigId == idINt).FirstOrDefault();
        foreach (DataRow row in csv.Rows) {
            var csvMapped = new MapperTable {
                EE_First_Name = namesFromColumnCsvMap.EE_First_Name != null && csv.Columns.Contains(namesFromColumnCsvMap.EE_First_Name.TrimEnd()) ? row[namesFromColumnCsvMap.EE_First_Name.TrimEnd()].ToString() : "",
                EE_Last_Name = namesFromColumnCsvMap.EE_Last_Name != null csv.Columns.Contains(namesFromColumnCsvMap.EE_Last_Name.TrimEnd()) ? row[namesFromColumnCsvMap.EE_Last_Name.TrimEnd()].ToString() : "",
                EE_MI = namesFromColumnCsvMap.EE_MI != null && csv.Columns.Contains(namesFromColumnCsvMap.EE_MI.TrimEnd()) ? row[namesFromColumnCsvMap.EE_MI.TrimEnd()].ToString() : "",
            };
            //...
        }
    }
