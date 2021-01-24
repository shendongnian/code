    for(int i = excelPackage.Workbook.Worksheets.Length; i>=1; i--){
      var name = excelPackage.Workbook.Worksheets[i].Name.ToLower();
      if(name.Contains("week") || name.Contains("month")
        continue;
      else
        excelPackage.Workbook.Worksheets.Delete(i);
    }
