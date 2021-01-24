	var ds1 = SelectedQCItems.Copy();
	var ds2 = SelectedQCItems.Copy();
	var lastRowIndex = SelectedQCItems.Tables[0].Rows.Count - 1;
	var halfwayIndex = SelectedQCItems.Tables[0].Rows.Count / 2 - 1;
	for (int i = lastRowIndex; i > halfwayIndex; i--)
	{
		ds1.Tables[0].Rows.RemoveAt(i);
	}
	ds1.AcceptChanges();
	for (int i = halfwayIndex; i > -1; i--)
	{
		ds2.Tables[0].Rows.RemoveAt(i);
	}
	ds2.AcceptChanges();
	var one = ds1.Tables[0].Rows.Count;
	var two = ds2.Tables[0].Rows.Count;
	gridviewQc1.DataSource = ds1;
	gridviewQc1.DataBind();
	gridviewQc2.DataSource = ds2;
	gridviewQc2.DataBind();
