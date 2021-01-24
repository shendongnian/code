    protected void btnExportToPDF_Click(object sender, EventArgs e)
        {
            GridView[] gvExcel = new GridView[] { gridvw1,gridvw2,gridvw3 };
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            MemoryStream ms = new MemoryStream();
            PdfWriter.GetInstance(pdfDoc, ms);
            pdfDoc.Open();
            for (int i = 0; i < gvExcel.Length; i++)
            {
                if (gvExcel[i].Visible)
                {
                    PdfPTable pdfTbl = new PdfPTable(gvExcel[i].HeaderRow.Cells.Count);
                    pdfTbl.SpacingAfter = 20f;
                    foreach (TableCell headerTblCell in gvExcel[i].HeaderRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(gvExcel[i].HeaderStyle.ForeColor);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(headerTblCell.Text));
                        pdfCell.BackgroundColor = new BaseColor(gvExcel[i].HeaderStyle.ForeColor);
                        pdfTbl.AddCell(pdfCell);
                    }
                    foreach (GridViewRow gvRow in gvExcel[i].Rows)
                    {
                        foreach (TableCell tblCell in gvRow.Cells)
                        {
                            Font font = new Font();
                            font.Color = new BaseColor(gvExcel[i].RowStyle.ForeColor);
                            PdfPCell pdfCell = new PdfPCell(new Phrase(tblCell.Text));
                            pdfCell.BackgroundColor = new BaseColor(gvExcel[i].RowStyle.ForeColor);
                            pdfTbl.AddCell(pdfCell);
                        }
                    }
                    pdfDoc.Add(pdfTbl);
                }
            }
            pdfDoc.Close();
            
            byte[] content = ms.ToArray();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=report_" + startDate + "-" + endDate + ".pdf");
            Response.BinaryWrite(content); 
            Response.Flush();
            Response.End();
        }
