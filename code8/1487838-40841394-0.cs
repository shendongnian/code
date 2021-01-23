    public FileResult ViewReport()
        {            
            string RptPath = Server.MapPath("~/Reports/Mymun_Lab/ComparisonStudy.rdlc");                  
            Microsoft.Reporting.WebForms.LocalReport rpt = new Microsoft.Reporting.WebForms.LocalReport(); 
            /* Bind Here Report Data Set */
            rpt.ReportPath = RptPath;
            string filePath = System.IO.Path.GetTempFileName();               
            Export(rpt, filePath);
            //CLOSE REPORT OBJECT           
            rpt.Dispose();
            return File(filePath, "application/pdf");
        } 
