        IssueDAO dbdata = new IssueDAO();
        dbdata.connectionString = ConfigurationManager.ConnectionStrings["TWCL_OPERATIONSConnectionString"].ConnectionString;
        getIssue.transactionDate = DateTime.Now; //Sets the transaction date to current date
        getIssue.status = -1;
        Item item = new Item();
        try
        {
            dbdata.createIssue(getIssue, item);//Creates the issue in the database
        }
        catch (Exception ex)
        {
            LogWrite logWriter = new LogWrite(ex.ToString());
            ViewBag.errorMessage = "Unable to complete the Issue. Please see Log file for more Information";
            return View("IssueItem", getIssue);
        }
        DataSet ds = ds = dbdata.GetReceipt(getIssue.requisitionNumber);
        LocalReport localreport = new LocalReport();
        localreport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Reciept.rdlc";
        localreport.DataSources.Add(new ReportDataSource("Receipt_Data", ds.Tables[0]));
        localreport.SetParameters(new ReportParameter("Req_num", getIssue.requisitionNumber));
        string reporttype = "PDF";
        string mimeType;
        string encoding;
        string fileNameExtension = "pdf";
        string deviceInfo = @"<DeviceInfo>              
                 <OutputFormat>PDF</OutputFormat>              
                 <PageWidth>8.5in</PageWidth>              
                 <PageHeight>11in</PageHeight>          
                 <MarginTop>0.25in</MarginTop>          
                 <MarginLeft>0.45in</MarginLeft>            
                 <MarginRight>0.45in</MarginRight>       
                 <MarginBottom>0.25in</MarginBottom></DeviceInfo>";
        Warning[] warnings;
        string[] streams;
        byte[] renderedBytes;
        renderedBytes = localreport.Render(
         reporttype, deviceInfo, out mimeType, out encoding, out fileNameExtension,
         out streams, out warnings);
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
        return File(reader, "application/pdf");
    }`
