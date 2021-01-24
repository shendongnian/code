            var pagesize = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A4);
            //Set Background color of pdf    
            pagesize.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            var left_margin = 25;
            var top_margin = 25;
            var bottom_margin = 25;
            iTextSharp.text.Document doc = new iTextSharp.text.Document(pagesize, left_margin, 10, top_margin, bottom_margin);
            string filePath = "D:\\myTask\\";
            string tempFileName = "tempXmlToWebPdf.pdf";
            string finalFileName = "XmlToWebPdf.pdf";
            string tempFilePath = filePath + tempFileName;
            string finalFilePath = filePath + finalFileName;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(tempFilePath, FileMode.Create));
                iTextSharp.text.Font mainFont = new iTextSharp.text.Font();
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font();
                mainFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000")));
                boldFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                Paragraph para = new Paragraph();
                // Read in the contents of the Receipt.htm file...
                string contents = System.IO.File.ReadAllText(Server.MapPath("~/Design/Template.html"));
                // Replace the placeholders with the user-specified text
                contents = contents.Replace("@FirstName", Model.FirstName);
                contents = contents.Replace("@CourseName", Model.CourseName);
                contents = contents.Replace("@Score", Convert.ToString(Model.Score));
                string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                contents = contents.Replace("@Date", date);
                contents = contents.Replace("@Path1", Server.MapPath("~/Content/Frontendcss/assets/Icon/elearning-logo.png").ToString());
                contents = contents.Replace("@Path2", Server.MapPath("~/Content/Frontendcss/assets/images/x.jpg").ToString());
                doc.Open();
                var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
                var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);
                // Enumerate the elements, adding each one to the Document...
                foreach (var htmlElement in parsedHtmlElements)
                    doc.Add(htmlElement as IElement);
                //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/Frontendcss/assets/Icon/elearning-logo.png"));
                //logo.SetAbsolutePosition(20, 20);
                //doc.Add(logo);
                //doc.Add(new Paragraph("Northwind Traders Receipt", titleFont));
                //var orderInfoTable = new PdfPTable(2);
                //orderInfoTable.HorizontalAlignment = 0;
                //orderInfoTable.SpacingBefore = 10;
                //orderInfoTable.SpacingAfter = 10;
                //orderInfoTable.DefaultCell.Border = 0;
                //orderInfoTable.SetWidths(new int[] { 1, 4 });
                //orderInfoTable.AddCell(new Phrase("Order:", boldTableFont));
                //orderInfoTable.AddCell(Model.CourseName);
                //orderInfoTable.AddCell(new Phrase("Price:", boldTableFont));
                //orderInfoTable.AddCell(Convert.ToString(Model.Score));
                //doc.Add(orderInfoTable);
                doc.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Response.AddHeader("Content-Disposition", "attachment;filename=eLearningCertificate.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile(tempFilePath);
            Response.End();
