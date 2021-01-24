    protected void Button3_Click(object sender, EventArgs e)
		{
			int randomvalue = new Random().Next(10);
			try
			{
				filename = Server.MapPath("~/Reports/Tro_Reports" + randomvalue + ".xlsx");
				using (var getReportCollection = new DataSet1())
				{
					using (var tableCollection = getReportCollection.Tables["SheetNames"])
					{
						var excelApplication = new Microsoft.Office.Interop.Excel.Application();
						try
						{
							var wb = excelApplication.Workbooks.Add();
							var collection = new Microsoft.Office.Interop.Excel.Worksheet[20];
							for (var i = 0; i < tableCollection.Columns.Count; i++)
							{
								collection[i] = wb.Worksheets.Add();
								collection[i].Name = tableCollection.Columns[i].ToString();
							}
							var thisWorksheet = collection[2];
							var thisRange = thisWorksheet.Range["A1"];
							thisRange.Value = "Event Summary Report";
							wb.SaveAs(filename);
							wb.Close();
						}
						finally
						{
							Marshal.ReleaseComObject(excelApplication);
						}
					}
				}
			}
			catch (ExternalException ex)
			{
				
			}
		}
