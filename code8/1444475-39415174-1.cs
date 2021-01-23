         var fileName = @"C:\ExcelFile.xlsx";
    
     SpreadsheetControl spreadsheetControl1 = new SpreadsheetControl();
    
     using (FileStream stream = new FileStream(fileName, FileMode.Open))
     {
         spreadsheetControl1.LoadDocument(stream, DocumentFormat.OpenXml);
     }
     IWorkbook workbook = spreadsheetControl1.Document;
     workbook.Options.Export.Csv.ValueSeparator = ';';
     workbook.SaveDocument("d:\\test.csv", DocumentFormat.Csv);
     string whole_file = System.IO.File.ReadAllText(FileName);
    
     // Split into lines.
     whole_file = whole_file.Replace('\n', '\r');
     string[] lines = whole_file.Split(new char[] { '\r' },
         StringSplitOptions.RemoveEmptyEntries);
    
     // See how many rows and columns there are.
     int num_rows = lines.Length;
     int num_cols = lines[0].Split(',').Length;
    
     // Allocate the data array.
     string[,] values = new string[num_rows, num_cols];
    
     // Load the array.
     for (int r = 0; r < num_rows; r++)
     {
         string[] line_r = lines[r].Split(',');
         for (int c = 0; c < num_cols; c++)
             values[r, c] = line_r[c];
             //MessageBox.Show(line_r[c]);
     }
    
     int end;
     for (int i = 0; i < values.Length; i++)
     {
    
         int itemcount = values[i, 0].Count(x => x == ';');
         string tmpch = values[i, 0];
         string valeuradd;
    
         if (i == 0)
         {
             for (int x = 1; x < itemcount + 2; x++)
             {
                 end = tmpch.IndexOf(";");
                 if (end <= 0) { end = tmpch.Length; }
                 valeuradd = tmpch.Substring(0, end);                       
                 tmpch = tmpch.Substring(end + 1);                       
                 DT.Columns.Add(valeuradd);
             }
         }
    
         else
         {
             DataRow row;
             row = DT.NewRow();
             for (int j = 1; j < itemcount + 2; j++)
             {
    
                 end = tmpch.IndexOf(";");
                 //MessageBox.Show(j.ToString());
                 if (end <= 0) { end = tmpch.Length; }
                 valeuradd = tmpch.Substring(0, end);
                 row[j - 1] = valeuradd;                       
               tmpch = tmpch.Substring(end + 1);                       
             }
             DT.Rows.Add(row);
         }
     }
