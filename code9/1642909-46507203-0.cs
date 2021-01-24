	#region DeleteRow
	/// <summary>
	/// Delete the specified row from the worksheet.
	/// </summary>
	/// <param name="row">A row to be deleted</param>
	public void DeleteRow(int row)
	{
		DeleteRow(row, 1);
	}
	/// <summary>
	/// Delete the specified row from the worksheet.
	/// </summary>
	/// <param name="rowFrom">The start row</param>
	/// <param name="rows">Number of rows to delete</param>
	public void DeleteRow(int rowFrom, int rows)
	{
		CheckSheetType();
		if (rowFrom < 1 || rowFrom + rows > ExcelPackage.MaxRows)
		{
			throw(new ArgumentException("Row out of range. Spans from 1 to " + ExcelPackage.MaxRows.ToString(CultureInfo.InvariantCulture)));
		}
		lock (this)
		{
			_values.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			_formulas.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			_flags.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			_commentsStore.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			_hyperLinks.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			_names.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			Comments.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns);
			Workbook.Names.Delete(rowFrom, 0, rows, ExcelPackage.MaxColumns, n => n.Worksheet == this);
			AdjustFormulasRow(rowFrom, rows);
			FixMergedCellsRow(rowFrom, rows, true);
			foreach (var tbl in Tables)
			{
				tbl.Address = tbl.Address.DeleteRow(rowFrom, rows);
			}
			foreach (var ptbl in PivotTables)
			{
				if (ptbl.Address.Start.Row > rowFrom + rows)
				{
					ptbl.Address = ptbl.Address.DeleteRow(rowFrom, rows);
				}
			}
		}
	}
