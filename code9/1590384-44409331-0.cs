    int index = DropDownList1.SelectedIndex;
    int max = DropDownList1.Items.Count;
    for (int i = 0; i < max; i++)
    {
        if (i != index)
        {
            Excel.Worksheet worksheets = (Excel.Worksheet)xlWorkBook.Sheets[i];
            worksheets.Delete();
        }
    }
