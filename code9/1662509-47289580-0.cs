               using (MemoryStream ms = new MemoryStream())
            {
                var pdf = PdfGenerator.GeneratePdf(RenderRazorViewToString("TicketTemplateBig", model), PdfSharp.PageSize.A4);
                pdf.Save(ms, false);
                using (MemoryStream ms2 = new MemoryStream())
                {
                    Image image = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(RenderRazorViewToString("TicketTemplateBig", model));
                    image.Save(ms2, ImageFormat.Png);
                    ms2.Position = 0;
                    await ms.FlushAsync();
                    await ms2.FlushAsync();
                    mm.Attachments.Add(new Attachment(ms, string.Format("Ticket.pdf"), "application/pdf"));
                    mm.Attachments.Add(new Attachment(ms2, string.Format("Ticket.png"), "application/png"));
                    await client.SendMailAsync(mm);
                }
            }
