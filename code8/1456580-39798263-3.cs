    Range usedRange = xlWorkSheet.UsedRange;
    string data = "";
    Excel.Range curRange;
    List<string> itemsToAdd = new List<string>();
    foreach (Excel.Range row in usedRange.Rows)
    {
      curRange = (Excel.Range)row.Cells[1, 1];
      if (curRange.Cells.Value2 != null)
      {
        data = curRange.Cells.Value2.ToString();
        itemsToAdd.Add(data);
      }
    }
    listBox1.DataSource = itemsToAdd;
    xlWorkBook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);  
    xlexcel.Quit();
