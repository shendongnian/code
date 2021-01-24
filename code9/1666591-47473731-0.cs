	var csv = string.Join(
		Environment.NewLine
		, File.ReadLines(csvfileinfo.FullName).Where(line => !string.IsNullOrWhiteSpace(line))
	);
    Package.Workbook.Worksheets["Believer List"].Cells["A1"].LoadFromText(csv, format, OfficeOpenXml.Table.TableStyles.Medium27, true);
