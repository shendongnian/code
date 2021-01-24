    public FileResult GetRDLC() {
       var fname = "MyFileName.pdf";
       var pdf = new byte[] { };
    
       /* FILL pdf-array HERE */
    
       // Add header to tell browser this is a download
       Response.AppendHeader("content-disposition", "inline; filename=" + fname);
       return File(pdf, "application/pdf", "");
    }
