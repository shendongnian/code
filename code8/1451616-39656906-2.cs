		public void CreateTable(string dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            Document doc = new Document(pdfDoc);
            Table tab = new Table(6);
            //Table should take up the entire width
            tab.SetWidthPercent(100);
            tab.SetPadding(3);
            //Because table takes up the entire width, this has no visual effect, but otherwise it will center the table
            tab.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            //Header cell
            Cell hCell = new Cell(1, 6);
            hCell.Add(new Paragraph("Centered Header"));
            //Text is aligned by calling SetTextAlignment
            hCell.SetTextAlignment(TextAlignment.CENTER);
            tab.AddCell(hCell);
            //Subheaders
            Cell shCellL = new Cell(1, 3);
            shCellL.Add(new Paragraph("Left aligned data"));
            shCellL.SetTextAlignment(TextAlignment.LEFT);
            Cell shCellR = new Cell(1, 3);
            shCellR.Add(new Paragraph("Right aligned data"));
            shCellR.SetTextAlignment(TextAlignment.RIGHT);
            tab.AddCell(shCellL);
            tab.AddCell(shCellR);
            //col names
            for (int i = 0; i < 6; i++)
            {
                Cell colName = new Cell();
                colName.Add(new Paragraph(String.Format("Col {0}", i)));
                colName.SetTextAlignment(TextAlignment.CENTER);
                tab.AddCell(colName);
            }
            //data cols
            for (int i = 1; i < 5; i++)
            {
                Cell nC = new Cell();
                nC.Add(new Paragraph("" + i));
                tab.AddCell(nC);
                for (int j = 0; j < 3; j++)
                {
                    Cell dCell = new Cell();
                    //When Setting borders to NO_BORDER, remember to Set that border to NO_BORDER in all adjoining cells
                    dCell.SetBorderLeft(Border.NO_BORDER);
                    dCell.SetBorderRight(Border.NO_BORDER);
                    dCell.Add(new Paragraph(String.Format("Entry, {0}-{1}", i, j)));
                    //Dashed, striped, grooved and more can be specified
                    if (i != 4) dCell.SetBorderBottom(new DashedBorder(1f));
                    tab.AddCell(dCell);
                }
                for (int k = 4; k < 6; k++)
                {
                    Cell d2Cell = new Cell();
                    //Only the rightmost border will not show, since the left-most borders of the neighbouring cells still get drawn
                    d2Cell.SetBorderRight(Border.NO_BORDER);
                    d2Cell.Add(new Paragraph(String.Format("Entry, {0}-{1}", i, k)).SetFontColor(Color.RED));
                    //Specific borders apart from NO_BORDER do override the default
                    if (i != 4) d2Cell.SetBorderBottom(new DashedBorder(1f));
                    tab.AddCell(d2Cell);
                }
            }
            //footer cell
            Cell fCell = new Cell(1, 6);
            fCell.Add(new Paragraph("footer"));
            tab.AddCell(fCell);
            //Add table to document
            doc.Add(new Paragraph("Complex Table example"));
            doc.Add(tab);
            doc.Close();
        }
		
