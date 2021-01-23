            //Creates a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Adds a page.
            PdfPage page = doc.Pages.Add();
            //create a new PDF string format
            PdfStringFormat drawFormat = new PdfStringFormat();
            drawFormat.WordWrap = PdfWordWrapType.Word;
            drawFormat.Alignment = PdfTextAlignment.Justify;
            drawFormat.LineAlignment = PdfVerticalAlignment.Top;
            //Set the font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            //Create a brush.
            PdfBrush brush = PdfBrushes.Red;
            //bounds
            RectangleF bounds = new RectangleF(new PointF(10, 10), new SizeF(page.Graphics.ClientSize.Width - 30, page.Graphics.ClientSize.Height - 20));
            //Create a new text elememt
            PdfTextElement element = new PdfTextElement(text, font, brush);
            //Set the string format
            element.StringFormat = drawFormat;
            //Draw the text element
            PdfLayoutResult result =  element.Draw(page, bounds);
            // Draw the string one after another.
            result = element.Draw(result.Page, new RectangleF(result.Bounds.X, result.Bounds.Bottom + 10, result.Bounds.Width, result.Bounds.Height));
            // Creates a PdfLightTable.
            PdfLightTable pdfLightTable = new PdfLightTable();
            //Add colums to light table
            pdfLightTable.Columns.Add(new PdfColumn("Name"));
            pdfLightTable.Columns.Add(new PdfColumn("Age"));
            pdfLightTable.Columns.Add(new PdfColumn("Sex"));
            //Add row        
            pdfLightTable.Rows.Add(new string[] { "abc", "21", "Male" });
            //Includes the style to display the header of the light table.
            pdfLightTable.Style.ShowHeader = true;
            //Draws PdfLightTable and returns the rendered bounds.
            result = pdfLightTable.Draw(page, new PointF(result.Bounds.Left,result.Bounds.Bottom+20));
            //draw string with returned bounds from table
            result =  element.Draw(result.Page, result.Bounds.X, result.Bounds.Bottom + 10);
            //draw string with returned bounds from table
            element.Draw(result.Page, result.Bounds.X, result.Bounds.Bottom + 10);
            MemoryStream stream = new MemoryStream();
          
            //Saves the document.
            doc.Save(stream);
            doc.Close(true);
