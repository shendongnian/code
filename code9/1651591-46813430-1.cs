        var doc = new iTextSharp.text.Document();
        var reader = new PdfReader(renderedBytes);
		byte[] bytes;
        using (FileStream fs = new FileStream(Server.MapPath("~/Receipt" +
             Convert.ToString(Session["CurrentUserName"]) + ".pdf"), FileMode.Create))
        {
            PdfStamper stamper = new PdfStamper(reader, fs);
            string Printer = "Xerox Phaser 3635MFP PCL6";
            // This is the script for automatically printing the pdf in acrobat viewer
            stamper.JavaScript = "var pp = getPrintParams();pp.interactive =pp.constants.interactionLevel.automatic; pp.printerName = " +
                           Printer + ";print(pp);\r";
            stamper.Close();
			bytes = new byte[fs.Length];
			fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
        }
        reader.Close();
        System.IO.File.Delete(Server.MapPath("~/Receipt.pdf"));
        //Here we returns the file result for view(PDF)
        ModelState.Clear();
        Session.Clear(); //Clears the session variable for reuse 
        return File(bytes, "application/pdf");
    }`
