    Workbook workbook = new Workbook("e:\\test2\\Book1.xlsx");
                //Add watermark to the first worksheet.
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                Aspose.Cells.Drawing.MsoPresetTextEffect effect = Aspose.Cells.Drawing.MsoPresetTextEffect.TextEffect2;
                Aspose.Cells.Drawing.Shape wordart = sheet.Shapes.AddTextEffect(effect, "WATERMARKTEXT", "Arial Black", 47, false, false, 1, 1, 1, 1, 50, 300);
                Aspose.Cells.Drawing.MsoFillFormat wordArtFormat = wordart.FillFormat;
                wordArtFormat.ForeColor = System.Drawing.Color.Red;
                wordArtFormat.Transparency = 0.8;
                Aspose.Cells.Drawing.MsoLineFormat lineFormat = wordart.LineFormat;
                lineFormat.IsVisible = false;
                
    
                //Now add watermark to the second worksheet as it is.
                Aspose.Cells.Worksheet worksheet1 = workbook.Worksheets[1];
                worksheet1.Shapes.AddCopy(wordart, wordart.UpperLeftRow, wordart.Top, wordart.UpperLeftColumn, wordart.Left);
    
    
                //Now add watermark to the third worksheet vertically.
                Aspose.Cells.Worksheet worksheet2 = workbook.Worksheets[2];
                worksheet2.Shapes.AddCopy(wordart, wordart.UpperLeftRow, wordart.Top, wordart.UpperLeftColumn, wordart.Left);
                worksheet2.Shapes[0].RotationAngle = 90;
    
                workbook.Save("e:\\test2\\out.xlsx");
