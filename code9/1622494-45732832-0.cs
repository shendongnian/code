    string FileName = @"DataSource\sampleData.xml";
	var excelDocName = @"c:\temp\OutExcel.xlsx";
	var aFile = new FileInfo(excelDocName);
	DataSet ds = new DataSet();
	ds.ReadXml(FileName);
	DataTable table = ds.Tables[0];
	
    using (ExcelPackage pck = new ExcelPackage(aFile))
	{
		ExcelWorksheet ws = pck.Workbook.Worksheets[1];
		const int startRow = 2;
		int mergestarttrow = 2;
		int rw = startRow;
		int RefNo = 0;
		int TTLCONS = 0;
		string[] mergedColNamed = new string[] { "SNO", "_NAME", "CAUSE_SUBCAUSE", "_AREAS", "CONS", "GRIDNAM" };
		Dictionary<string, string> mergeRange = new Dictionary<string, string>() { { "SNO", "A" }, { "_NAME", "B" }, { "CAUSE_SUBCAUSE", "C" }, { "_AREAS", "D" }, { "CONS", "E" }, { "GRIDNAM", "F" } };
		if (table.Rows.Count != 0)
		{
			foreach (DataRow row in table.Rows)
			{
				bool needMerge = false;
				bool checkMerge = false;
                       //Hold to compare with next iteration and based to condition match Enable Check Merge Flag
				int CurrentRefNo = System.Convert.ToInt32(row["SNO"]);
				if (RefNo > 0)
				{
					if (RefNo == CurrentRefNo)
					{
						checkMerge = true;
						mergeRange = mergeRange = mergeRange = new Dictionary<string, string>() { { "SNO", "A" }, { "_NAME", "B" }, { "CAUSE_SUBCAUSE", "C" }, { "_AREAS", "D" }, { "CONS", "E" }, { "GRIDNAM", "F" } };
					}
					else
					{
						mergestarttrow = rw;
						needMerge = true;
					}
				}
				int col = 1;
				if (rw > startRow)
					ws.InsertRow(rw, 1);
				if (needMerge)
				{
					for (int i = 0; i < mergedColNamed.Length; i++)
					{
						string MergeRangeValue = mergeRange.FirstOrDefault(x => x.Key == mergedColNamed[i]).Value;
				    	using (ExcelRange Rng = ws.Cells[MergeRangeValue])
						{
							Rng.Merge = true;
							ws.Cells[MergeRangeValue].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[MergeRangeValue].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
									Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
									Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
									Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
									Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
									if (mergedColNamed[i] == "CONS")
									{
										Rng.Value = TTLCONS;
										TTLCONS = 0;
										Rng.Style.Numberformat.Format = "0";
									}
									if (mergedColNamed[i] == "SNO")
									{
										Rng.Style.Numberformat.Format = "0";
									}
								}
							}
							mergeRange = new Dictionary<string, string>() { { "SNO", "A" }, { "_NAME", "B" }, { "CAUSE_SUBCAUSE", "C" }, { "_AREAS", "D" }, { "CONS", "E" }, { "GRIDNAM", "F" } };
						}
						foreach (DataColumn dc in table.Columns)
						{
							if (mergedColNamed.Contains(dc.ColumnName.ToUpper()))
							{
								if (dc.ColumnName.ToUpper() == "CONS")
									TTLCONS = TTLCONS + System.Convert.ToInt32(row[dc]);
								if (!checkMerge)//First Row
								{
									if (dc.ColumnName.ToUpper() == "SNO")
										RefNo = System.Convert.ToInt32(row[dc]);
									ws.Cells[rw, col].Value = row[dc].ToString();
									ws.Cells[rw, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
									ws.Cells[rw, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
									ws.Cells[rw, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
									ws.Cells[rw, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
									ws.Cells[rw, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
									ws.Cells[rw, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
									if (dc.ColumnName.ToUpper() == "CONS")
									{
										ws.Cells[rw, col].Style.Numberformat.Format = "0";
									}
								}
								else //No Need to set Cell Values as ultimately we will merge only updating the merge range
								{
									string MergeRangeKey = mergeRange.FirstOrDefault(x => x.Value == mergeRange[dc.ColumnName.ToUpper()]).Key;
									string MergeRangeValue = mergeRange[dc.ColumnName.ToUpper()];
									mergeRange[MergeRangeKey] = string.Format(mergeRange[dc.ColumnName.ToUpper()] + "{0}:" + mergeRange[dc.ColumnName.ToUpper()] + "{1}", mergestarttrow, rw);
								}
							}
							else
							{
								ws.Cells[rw, col].Value = row[dc].ToString();
								ws.Cells[rw, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
								ws.Cells[rw, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
								ws.Cells[rw, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
								ws.Cells[rw, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
							}
							col++;
						}
						rw++;
					}
				}
				ws.Cells.AutoFitColumns();
				pck.Save();
				System.Diagnostics.Process.Start(excelDocName);
 
