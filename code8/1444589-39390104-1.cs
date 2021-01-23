    for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
    {
      for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
      {
        str = str +"|"+ (range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString();
      }
      sw.WriteLine(str);
      str = "";
    } 
