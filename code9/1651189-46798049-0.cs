            msg.Subject = sSubject;
    
            msg.Body = sBody;
    
            msg.IsBodyHtml = true;
    
            var smpt = new SmtpClient();
            smpt.Port = ###;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                msg.Attachments.Add(new Attachment(new MemoryStream(bytes), "RECEIPT.pdf"));
                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
     smpt.Send(msg);
