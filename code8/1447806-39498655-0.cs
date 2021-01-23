    public void Gera_Pdf()
            {
                using (
                    var fileStream = new System.IO.FileStream("output.pdf", System.IO.FileMode.Create,
                        System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    var font3 = iTextSharp.text.FontFactory.GetFont("Calibri", 10);
                    DataTable dt = (DataTable) Session["DataSetValores"];
                    PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
                    PdfPRow row = null;
                    float[] widths = new float[] {4f, 4f, 4f, 4f,4f,4f,4f};
    
                    pdfTable.SetWidths(widths);
    
                    pdfTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new iText.Phrase("Products"));
    
                    cell.Colspan = dt.Columns.Count;
    
                    
    
                        pdfTable.AddCell(new iText.Phrase("NF", font3));
                        pdfTable.AddCell(new iText.Phrase("Emissão", font3));
                        pdfTable.AddCell(new iText.Phrase("Vencimento", font3));
                        pdfTable.AddCell(new iText.Phrase("Dias", font3));
                        pdfTable.AddCell(new iText.Phrase("Valor(R$)", font3));
                        pdfTable.AddCell(new iText.Phrase("Encargos(R$)", font3));
                        pdfTable.AddCell(new iText.Phrase("Vlr. Final(R$)", font3));
                    
    
                    foreach (DataRow r in dt.Rows)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            pdfTable.AddCell(new iText.Phrase(r[0].ToString(), font3));
                            pdfTable.AddCell(new iText.Phrase(r[1].ToString(), font3));
                            pdfTable.AddCell(new iText.Phrase(r[2].ToString(), font3));
                            pdfTable.AddCell(new iText.Phrase(r[3].ToString(), font3));
                            pdfTable.AddCell(new iText.Phrase(r[4].ToString(), font3));
                            pdfTable.AddCell(new iText.Phrase(r[5].ToString(), font3));
                            pdfTable.AddCell(new iText.Phrase(r[6].ToString(), font3));
                        }
    
                    }
                    var document = new iTextSharp.text.Document();
                        var pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream);
                        document.Open();
                        
                        iTextSharp.text.FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
                        var font = iTextSharp.text.FontFactory.GetFont("Calibri", 14);
                        var font2 = iTextSharp.text.FontFactory.GetFont("Calibri", 10);
                        var image = iTextSharp.text.Image.GetInstance("Klabin.png");
                        image.ScaleToFit(70, 70);
                        image.SetAbsolutePosition(25, 780);
                        var paragraph = new iTextSharp.text.Paragraph("DADOS DO ACEITE", font);
                        paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        document.Add(paragraph);
                        paragraph =
                            new iTextSharp.text.Paragraph(
                                "Empresa:" + lblEmpresas.Text + " /Representante:" + lblRepresentante.Text + " /CNPJ:" +
                                lblCnpj.Text, font2);
                        paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        document.Add(paragraph);
                        var contentByte = pdfWriter.DirectContent;
                        contentByte.AddImage(image);
                    paragraph = new iTextSharp.text.Paragraph("");
                    document.Add(paragraph);
                    paragraph = new iTextSharp.text.Paragraph("");
                    paragraph.SpacingAfter = 40f;
                    document.Add(paragraph);
                    
                    document.Add(pdfTable);
                        document.Close();
                        byte[] bytes = System.IO.File.ReadAllBytes("output.pdf");
                        System.IO.File.WriteAllBytes("myfile.pdf", bytes);
                        Session["pdfBytes"] = bytes;
                        System.Diagnostics.Process.Start("output.pdf");
                    }
                }
