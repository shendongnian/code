	//assigns range from row like in : ws.Range[s][1, 1].Row [ws.range["A10:L90][1,1].row // returns count for further use
	/*
	r = ws.Range
	[
		ws.Cells[ws.Range[s][1, 1].Row, 1]
		, ws.Cells[
			ws.Range[s][1, 1].Row + ws.Range[s].Rows.Count - 1
			, ws.Range[s][1, 1].Column + ws.Range[s].Columns.Count - 1
			]
	];
	*/
	//*****Rough translation with s as any proper Excel string range
	var srange = ws.Cells[s];
	var startcell = srange.Start;
	var endcell = srange[srange.End.Row - 1, srange.End.Column - 1].Start; // or if you just want the end you can do = srange.End
    //Reset the indexer
    srange = ws.Cells[s];
	r = srange[startcell.Row, startcell.Column, endcell.Row, endcell.Column];
	//*****From there you can just set formatting as you like
	//setting certain cells to NumberFormat
	//ws.Range[ws.Cells[r[1, 1].Row, 3], ws.Cells[r[1, 1].Row + r.Rows.Count - 1, r[1, 1].Column + r.Columns.Count - 1]].NumberFormat = "0.00";
	r[1, 3, r.End.Row - 1, r.End.Column - 1].Style.Numberformat.Format = "0.00";
	//for the range in r sort data based on index []
	//r.Sort(Key1: r[1, 3], Order1: Excel.XlSortOrder.xlDescending, Key2: r[1, r.Columns.Count], Order2: Excel.XlSortOrder.xlDescending, Key3: r[1, 2], Order3: Excel.XlSortOrder.xlDescending, Header: Excel.XlYesNoGuess.xlNo, OrderCustom: 1, MatchCase: false, Orientation: Excel.XlSortOrientation.xlSortRows, DataOption1: Excel.XlSortDataOption.xlSortNormal, DataOption2: Excel.XlSortDataOption.xlSortNormal, DataOption3: Excel.XlSortDataOption.xlSortNormal
	r.Sort(new[] {3, r.Columns - 1}, new[] {true, true});
