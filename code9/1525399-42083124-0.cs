    xl.Range myRange = emptyCellsDel.Range["A:C"];
    const int aCol = 1; const int bCol = 2; const int cCol = 3;
    List<int> rowsToDelete = new List<int>();
    for (int i = 1; i < MySheet.UsedRange.Rows.Count; i++)
    {
        if ((MySheet.Cells[i, aCol].Value ?? "").ToString() == "" &&
            (MySheet.Cells[i, bCol].Value ?? "").ToString() == "" &&
            (MySheet.Cells[i, cCol].Value ?? "").ToString() == "")
        {
            rowsToDelete.Add(i);
        }
    }
    foreach (int row in rowsToDelete) { ((Range)(MySheet.Rows[row])).Delete(XlDirection.xlUp); }
