        private void SplitFile(string targetPath, string sourceFile)
		{
			bool isSave;
			Excel.XlFileFormat fileFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
			string exportFormat = "";
			if (cboExcel.Checked) //set the output format
				exportFormat = "XLSX";
			else if (cboCsv.Checked)
				exportFormat = "CSV";
			Excel.Application xlApp = new Excel.Application(); //object for controlling Excel
			Excel.Workbook xlFile = xlApp.Workbooks.Open(txtFilePath.Text); //open the source file
			xlApp.DisplayAlerts = false; //override Excel save dialog message
			int TabCount = xlFile.Worksheets.Count; //total count of the tabs in the file
			int sheetCount = 0; //this will be used to output the number of exported sheets
			for (int i = 1; i <= TabCount; i++) //for each sheet in the workbook...
			{
				isSave = true; //Must reset to true
				string sheetName = xlFile.Sheets[i].Name;
				string newFilename = System.IO.Path.Combine(targetPath, sheetName); //set the filename with full path, but no extension
				toolStripStatus.Text = "Exporting: " + sheetName; //update the status bar
				Excel.Worksheet tempSheet = xlApp.Worksheets[i]; //Current tab will be saved to this in a new workbook
				tempSheet.Copy();
				Excel.Workbook tempBook = xlApp.ActiveWorkbook;
				try
				{
					switch (exportFormat) //if the file does NOT exist OR if does and the the user wants to overwrite it, do the export and increase the sheetCount by 1
					{
						case "CSV":
							newFilename += ".csv";
							fileFormat = Excel.XlFileFormat.xlCSV;
							break;
						case "XLSX":
							newFilename += ".xlsx";
							fileFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
							break;
					}
					if (File.Exists(newFilename))
						isSave = (MessageBox.Show(sheetName + ".xlsx already exists. Overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes);
					if (isSave)
					{
						tempBook.SaveAs(newFilename, fileFormat);
						tempBook.Close(false);
						sheetCount++;
					}
				}
				catch (Exception ex)
				{
					toolStripStatus.Text = "Error!";
					string errorMessage = "Error Exporting " + sheetName + System.Environment.NewLine + "Original Message: " + ex.Message;
					MessageBox.Show(errorMessage, "Error Exporting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					toolStripStatus.Text = "Ready";
				}
			}
			xlFile.Close(false);
			GC.Collect();
			GC.WaitForFullGCComplete();
			GC.Collect();
			GC.WaitForFullGCComplete();
			MessageBox.Show("Well done!");
		}
