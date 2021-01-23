      public static MemoryStream ExportToExcelWithCompanyLogo(DataTable dt, string sheetName, string CompanyLogo,Dictionary<string, string> filters)
      {
      
      //Create new Excel Workbook
      var workbook = new HSSFWorkbook();
      //Create new Excel Sheet
      var sheet = workbook.CreateSheet(sheetName);
      
      // Add Image Section 
      var patriarch = sheet.CreateDrawingPatriarch();
      HSSFClientAnchor anchor;
      anchor = new HSSFClientAnchor(0, 0, 0, 0, (short)1, 1, (short)5, 6);
      anchor.AnchorType = 2;
      
      string imagesPath = CompanyLogo;
      //grab the image file
      //imagesPath = System.IO.Path.Combine(imageLocation, "image.jpg");
      //create an image from the path
      System.Drawing.Image image = System.Drawing.Image.FromFile(imagesPath);
      
      MemoryStream ims = new MemoryStream();
      //pull the memory stream from the image (I need this for the byte array later)
      image.Save(ims, System.Drawing.Imaging.ImageFormat.Jpeg);
      
      
      int index = workbook.AddPicture(ims.ToArray(), PictureType.JPEG);
      
      var picture = patriarch.CreatePicture(anchor, index);
      picture.Resize(0.8);
      //picture.LineStyle = HSSFPicture.LINESTYLE_DASHDOTGEL;
      sheet.ForceFormulaRecalculation = true;
      
      // End of Add image
      
      // font Style for Excel title
      HSSFFont hFont = (HSSFFont)workbook.CreateFont();
      hFont.FontHeightInPoints = 16;
      hFont.FontName = "Calibri";
      hFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
      
      HSSFCellStyle hStyle = (HSSFCellStyle)workbook.CreateCellStyle();
      hStyle.Alignment = HorizontalAlignment.Center;
      hStyle.VerticalAlignment = VerticalAlignment.Top;
      hStyle.SetFont(hFont);
      // end of excel title style
      
      // font for Table header Stylr
      HSSFFont thhFont = (HSSFFont)workbook.CreateFont();
      thhFont.FontHeightInPoints = 12;
      thhFont.FontName = "Calibri";
      thhFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
      
      HSSFCellStyle thhStyle = (HSSFCellStyle)workbook.CreateCellStyle();
      thhStyle.Alignment = HorizontalAlignment.Left;
      thhStyle.VerticalAlignment = VerticalAlignment.Top;
      thhStyle.SetFont(thhFont);
      // end of table header font
      
      
      
      var cra = new NPOI.SS.Util.CellRangeAddress(6, 7, 4, 9);
      sheet.AddMergedRegion(cra);
      
      // Add filters to sheet
      int filterRows = 9;
      foreach (var key in filters)
      {
      var FilterRow = sheet.CreateRow(filterRows);
      FilterRow.CreateCell(4).SetCellValue(key.Key + " : ");
      FilterRow.CreateCell(5).SetCellValue(key.Value);
      filterRows++;
      }
      
      
      var HeaderRowNumber = 9 + filters.Keys.Count + 1;
      //Add rows
      var headerRow = sheet.CreateRow(HeaderRowNumber);
      //int totalcolumns = dt.Columns.Count;
      int columncounter = 0;
      
      if (dt.Rows.Count > 0)
      {
      foreach (DataColumn c in dt.Columns)
      {
      var cell = headerRow.CreateCell(columncounter + 1);
      cell.SetCellValue(c.ColumnName);
      cell.CellStyle = thhStyle;
      columncounter++;
      }
      //(Optional) freeze the header row so it is not scrolled
      //sheet.CreateFreezePane(0, 1, 0, 1);
      int rowNumber = HeaderRowNumber + 1;
      int dtrowNumber = 1;
      //Populate the sheet with values from the grid data
      foreach (var rows in dt.Rows)
      {
      //Create a new Row
      var row = sheet.CreateRow(rowNumber);
      //Set cell Value
      for (int cellnumber = 0; cellnumber < columncounter; cellnumber++)
      row.CreateCell(cellnumber + 1).SetCellValue(dt.Rows[dtrowNumber - 1][cellnumber].ToString());
      rowNumber++;
      dtrowNumber++;
      }
      // create 2 blank rows
      for (int i = 0; i < 2; i++)
      {
      //Create a new Row
      var row = sheet.CreateRow(rowNumber);
      //Set cell Value
      for (int cellnumber = 0; cellnumber < columncounter; cellnumber++)
      row.CreateCell(cellnumber + 1).SetCellValue("");
      rowNumber++;
      }
      
      // Add Date of extraction and source
      var extractedDate = sheet.CreateRow(rowNumber);
      var ecel = extractedDate.CreateCell(4);
      ecel.SetCellValue("Extracted Date : ");
      // ecel.CellStyle = hStyle;
      extractedDate.CreateCell(5).SetCellValue(DateTime.Now.ToString("dd - MMM - yyyy"));
      rowNumber++;
      
      
      
      var Disclaimer = sheet.CreateRow(rowNumber);
      var dcel = Disclaimer.CreateCell(4);
      dcel.SetCellValue("Disclaimer : ");
      // dcel.CellStyle = hStyle;
      Disclaimer.CreateCell(5).SetCellValue("All Rights Reserved.");
      rowNumber++;
      
      var Disclaimer1 = sheet.CreateRow(rowNumber);
      Disclaimer1.CreateCell(5).SetCellValue("Give some information at footer");
      rowNumber++;
      
      }
      else
      {
      for (int i = 0; i <= 10; i++)
      headerRow.CreateCell(i).SetCellValue("");
      }
      // End of add rows
      //Write the Workbook to a memory stream
      MemoryStream output = new MemoryStream();
      workbook.Write(output);
      return output;
      
      }
