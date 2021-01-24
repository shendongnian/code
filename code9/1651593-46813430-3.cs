    var doc = new iTextSharp.text.Document();
        var reader = new PdfReader(renderedBytes);
		FileStream fs = new FileStream(Server.MapPath("~/Receipt" +
             Convert.ToString(Session["CurrentUserName"]) + ".pdf"), FileMode.Create)
            PdfStamper stamper = new PdfStamper(reader, fs);
            string Printer = "Xerox Phaser 3635MFP PCL6";
            // This is the script for automatically printing the pdf in acrobat viewer
            stamper.JavaScript = "var pp = getPrintParams();pp.interactive =pp.constants.interactionLevel.automatic; pp.printerName = " +
                           Printer + ";print(pp);\r";
            stamper.Close();
        reader.Close();
        byte[] bytes = new byte[fs.Length];
        fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
        fs.Close();
        System.IO.File.Delete(Server.MapPath(Server.MapPath("~/Receipt" +
             Convert.ToString(Session["CurrentUserName"]) + ".pdf"));
        //Here we returns the file result for view(PDF)
        ModelState.Clear();
        Session.Clear(); //Clears the session variable for reuse 
        return File(bytes, "application/pdf");
