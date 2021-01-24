                /*datos del LA LIQUIDACIÓN*/
                //1° linea
                paragraph.Clear();
                paragraph.Font = new Font(FontFactory.GetFont("Arial", 10, Font.BOLD));
                paragraph.Alignment = Element.ALIGN_CENTER;//here is the change
                paragraph.Add("H A B E R E S");
                PdfPCell cell2 = new PdfPCell();
                cell2.Border = Rectangle.NO_BORDER;
                cell2.PaddingTop = -7;
                cell2.AddElement(paragraph);
                cell2.Colspan = 3;
                table2.AddCell(cell2);
                paragraph.Clear();
