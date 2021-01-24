     if (!string.IsNullOrEmpty(HeaderText))
                {
                    PdfPTable Header = new PdfPTable(1);
                    Header.SpacingBefore = 8;
                    Header.DefaultCell.Padding = 1;
                    Header.WidthPercentage = 100;
                    Header.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Header.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
    
                    PdfPCell cell1 = new PdfPCell();
                    cell1.BorderWidth = 0.001F;
                    cell1.BackgroundColor = new BaseColor(250, 250, 250);
                    cell1.BorderColor = new BaseColor(100, 100, 100);
                    cell1.Phrase = new Phrase(HeaderText, fontBold);
                    Header.AddCell(cell1);
                    pdfReport.Add(ptDataHeader);
                }
