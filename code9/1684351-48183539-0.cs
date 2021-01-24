	private void ExportToExcelFile(DataTable table, string filename)
	{
		string fileNameOut = filename; // Environment.CurrentDirectory + "\\Exportation.xlsx";
		if (File.Exists(@fileNameOut)) File.Delete(@fileNameOut);       // If the file exist, then detele the file
		FileInfo newFile = new FileInfo(@fileNameOut);
		ExcelPackage package = new ExcelPackage(newFile);
		var wsDt = package.Workbook.Worksheets.Add(string.Format("Data Exported"));
		// Load the datatable and set the number formats...
		wsDt.Cells["A1"].LoadFromDataTable(table, true, TableStyles.Light9);
		var headerCells = wsDt.Cells[1, 1, 1, wsDt.Tables[0].Columns.Count];
		var headerFont = headerCells.Style.Font;
		headerFont.Bold = true;  //headerFont.Italic = true;
		//headerFont.SetFromFont(new Font("Calibri", 12, FontStyle.Bold));   //headerFont.Color.SetColor(Color.DarkBlue);
		// Disable Autofilter
		wsDt.Tables[0].ShowFilter = false;
		// Formating numeric type or date type
		// wsDt.Column(1).Style.Numberformat.Format = "dd/mm/yyyy";     // Column: TimeStamp "yyyy-mm-dd"
		// AutoFitColumns ALL columns
		for (int i = 1; i <= wsDt.Tables[0].Columns.Count; i++)
			wsDt.Column(i).AutoFit();
		/*
		wsDt.Column(1).AutoFit();   // TimeStamp
		wsDt.Column(2).AutoFit();   // FIRSTNAME
		wsDt.Column(3).AutoFit();   // LASTNAME
		wsDt.Column(4).AutoFit();   // TRANSPORT
		wsDt.Column(5).AutoFit();   // MODE
		wsDt.Column(6).AutoFit();   // MODECODE
		wsDt.Column(7).AutoFit();   // OBSERVATIONS
		*/
		// set some document properties
		package.Workbook.Properties.Title = "Data Export";
		package.Workbook.Properties.Author = "My Company LLC";
		package.Workbook.Properties.Comments = "Data Exported to Excel (OpenXML Format)";
		// set some extended property values
		package.Workbook.Properties.Company = "My Company LLC";
		// save the file
		package.Save();
		//Console.WriteLine("Exported data {0}...");
		//log.Info(string.Format("Exported data: {0}", airlinename));
	}
	private void btnExportToExcel_Click(object sender, EventArgs e)
	{
		bool bandExport_ddMMyyyy = false;
		//show a file save dialog and ensure the user selects
		//correct file to allow the export
		saveFileDialog1.Title = "Export to Excel file";
		saveFileDialog1.Filter = "Microsoft Excel Book 2010-2013(*.xlsx)|*.xlsx";
		if (saveFileDialog1.ShowDialog() == DialogResult.OK)
		{
			if (MessageBox.Show("¿You wish export in format 'dd/MM/yyyy'? (By default, the TimeStamp values will not be format).", Toolbox.AssemblyTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				bandExport_ddMMyyyy = true;
			if (!saveFileDialog1.FileName.Equals(String.Empty))
			{
				FileInfo file = new FileInfo(saveFileDialog1.FileName);
				if (file.Extension.Equals(".xlsx"))
				{
					// Determine the columns to be exported.
					DataTable dataResultsToExport = new DataTable();
					foreach (DataGridViewColumn col in dataGridView1.Columns)
						dataResultsToExport.Columns.Add(col.HeaderText);
					// Copy the data.
					foreach (DataGridViewRow row in dataGridView1.Rows)
					{
						DataRow dRow = dataResultsToExport.NewRow();
						foreach (DataGridViewCell cell in row.Cells)
						{
							// If the column is TimeStamp, we can format it as we want, dd/MM/yyyy.
							if (cell.ColumnIndex == 0 && bandExport_ddMMyyyy)
								dRow[cell.ColumnIndex] = String.Format("{0:dd/MM/yyyy}", cell.Value);
							else
								dRow[cell.ColumnIndex] = cell.Value;
						}
						dataResultsToExport.Rows.Add(dRow);
					}
					this.ExportToExcelFile(dataResultsToExport, saveFileDialog1.FileName);
					MessageBox.Show("The exportation works fine!", Toolbox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
					MessageBox.Show("Invalid type file, please select the correct type file.", Toolbox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
				MessageBox.Show("Spicify the file directory!", Toolbox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
