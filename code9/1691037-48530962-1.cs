		private static void PrintTest()
		{
			using (var pdfDoc = PdfDocument.Load("pdf doc path"))
			{
				using (var printDoc = pdfDoc.CreatePrintDocument())
				{
					var currentSettings = printDoc.PrinterSettings;
					SetDevModeFromFile(currentSettings, "bin file that has printer settings path");
					currentSettings.ToPage = 3;
					printDoc.Print();
				}
			}
		}
