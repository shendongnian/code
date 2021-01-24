    if ((CheckBox)gridView.Columns[0].GetCellContent(row)).IsChecked??false)
    {
    	var part = ((TextBlock)gridView.Columns[1].GetCellContent(row)).Text;
    	var code = ((TextBlock)gridView.Columns[2].GetCellContent(row)).Text;
    	var um = ((TextBlock)gridView.Columns[3].GetCellContent(row)).Text;
    	addToPartList(part, code, um);
    	checkCount += 1;
    }
