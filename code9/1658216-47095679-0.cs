    using (var output = new MemoryStream())
                {
                    using (var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 40, 40, 30, 90))
                    {
                        using (var writer = PdfWriter.GetInstance(document, output))
                        {
                            Phrase phrase = null;
                            PdfPCell cell = null;
                            PdfPTable table = null;
                            try
                            {
                                document.Open();
                                document.PageCount = 1;
                                writer.PageEvent = new Footer(data);
    
                                foreach (var item in data)
                                {
                                    table = new PdfPTable(1);
                                    table.SpacingBefore = 20;
                                    table.WidthPercentage = PageSize.A4.Width;
                                    float[] ProfessionalServices = new float[1];
                                    ProfessionalServices[0] = (float)(1 * PageSize.A4.Width);
                                    table.SetWidthPercentage(ProfessionalServices, PageSize.A4);
    
                                    phrase = new Phrase("Record :" + item);
                                    cell = new PdfPCell(phrase);
                                    cell.Border = 0;
                                    cell.Padding = 2;
                                    cell.Colspan = 3;
                                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    table.AddCell(cell);
    
                                    table.WriteSelectedRows(0, -1, document.Left, document.Top - (100 + 20), writer.DirectContent);
                                    document.Add(table);
    
                                    document.ResetPageCount();
                                    document.NewPage();
                                }
                                document.Close();
                            }
                            catch (Exception ex)
                            {
    
                            }
    
                            if (!Directory.Exists(current.Server.MapPath("~/bill-pdf/")))
                                Directory.CreateDirectory(current.Server.MapPath("~/bill-pdf/"));
                            string pdfFilePath = current.Server.MapPath("~/bill-pdf/" + guid + ".pdf");
                            File.WriteAllBytes(pdfFilePath, output.ToArray());
                            if (File.Exists(filePath))
                                File.Delete(filePath);
                        }
                    }
                }
