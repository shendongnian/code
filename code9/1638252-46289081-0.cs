    private void btnCrear_Click(object sender, EventArgs e)
        {
            Document doc = new Document(PageSize.LETTER);
            
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream((Application.StartupPath+"\\PSC.pdf"), FileMode.Create));
            doc.AddTitle("Recibo de Pago de Derechos Laborales");
            doc.AddCreator("Errol");
            doc.Open();
            /*Get Image and set size*/
            iTextSharp.text.Image SC = iTextSharp.text.Image.GetInstance(Application.StartupPath+"\\SimboloColones.png");
            SC.ScaleAbsolute(5, 8);
            
            PdfPTable table = new PdfPTable(3);/*3 columns*/
            table.TotalWidth = 588;
            table.LockedWidth = true;
            /*Cell 1*/
            Paragraph Preaviso = new Paragraph();
            Preaviso.Add(new Chunk("Preaviso"));
            Preaviso.Alignment = 2;
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 1;
            cell.HorizontalAlignment = 2;
            cell.BorderColor = BaseColor.BLACK;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 0;
            cell.BorderWidthLeft = 0;
            cell.AddElement(Preaviso);
            table.AddCell(cell);
            /*Cell 2*/
            Paragraph pPreaviso = new Paragraph();
            SC.ScaleAbsolute(5, 8);
            pPreaviso.Add(new Chunk(SC, 0, 0));
            pPreaviso.Add(new Chunk("Cant Pre"));
            pPreaviso.Alignment = 0;
            cell = new PdfPCell();
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            cell.BorderColor = BaseColor.BLACK;
            cell.AddElement(pPreaviso);
            table.AddCell(cell);
            /*Cell 3*/
            cell = new PdfPCell(new Phrase("                 "));
            cell.Colspan = 1;
            cell.HorizontalAlignment = 1;
            cell.BorderColor = BaseColor.BLACK;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 0;
            cell.BorderWidthLeft = 0;
            table.AddCell(cell);
            doc.Add(table);
            doc.Close();
            writer.Close();
            System.Diagnostics.Process.Start(Application.StartupPath+"\\PSC.pdf");
            
        }
