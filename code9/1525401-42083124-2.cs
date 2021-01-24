    xl.Range myRange = emptyCellsDel.Range["A:C"];
    const int aCol = 1; const int bCol = 2; const int cCol = 3;
    List<int> rowsToDelete = new List<int>();
    int rowCount = MySheet.UsedRange.Rows.Count
    for (int i = rowCount; i >= 1; i--)
    {
        if ((MySheet.Cells[i, aCol].Value2 ?? "").ToString() == "" &&
            (MySheet.Cells[i, bCol].Value2 ?? "").ToString() == "" &&
            (MySheet.Cells[i, cCol].Value2 ?? "").ToString() == "")
        {
            rowsToDelete.Add(i);
        }
    }
    foreach (int row in rowsToDelete) { ((Range)(MySheet.Rows[row])).Delete(XlDirection.xlUp); }
