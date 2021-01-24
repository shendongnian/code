     MemoryStream memorystream = new MemoryStream();
                workbook.Save(memorystream, Aspose.Cells.SaveFormat.Xlsx);
                byte[] bytes = memorystream.ToArray();
                memorystream.Position = 0;
                // Apply different Image and Print options
                var options = new Aspose.Cells.Rendering.ImageOrPrintOptions
                {
                    HorizontalResolution = 200,
                    VerticalResolution = 200
                };
                // Set Horizontal Resolution
                // Set Vertical Resolution
                var sr = new SheetRender(sheet, options);
                MemoryStream imageStream = new MemoryStream();
                sr.ToImage(0, imageStream);
                System.Drawing.Image image = Image.FromStream(imageStream);
                Shape oleObject = builder.InsertOleObject(memorystream, "Excel.Sheet.12", false, image);
