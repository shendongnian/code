    Range usedRange = xlWorkSheet.UsedRange;
    string data = "";
    Excel.Range curRange;
    List<string> itemsToAdd = new List<string>();
    foreach (Excel.Range row in usedRange.Rows)
    {
      curRange = (Excel.Range)row.Cells[1, 1];
      data = curRange.Cells.Value2.ToString();
      MessageBox.Show("Value: " + data);
      itemsToAdd.Add(data);
    }
    listBox1.DataSource = itemsToAdd;
