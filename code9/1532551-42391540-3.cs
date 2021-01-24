				        [HttpGet]
    public ActionResult ExportExcel(int? id, int? reportType)
    {
        
        List<pr_ReportData_Result> model = Context.pr_ReportData().ToList();
        ReportViewer viewer = new ReportViewer();
        try
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;
            viewer.ProcessingMode = ProcessingMode.Local;
            //viewer.LocalReport.EnableExternalImages = true;
            if (id == 1)
            {
                viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/Name1.rdlc");
            }
            else if (id == 2)
            {
                viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/Name2.rdlc");
            }
            string exportType = String.Empty;
            string exportExtension = String.Empty;
            if (reportType == 1)
            {
                exportType = "Excel";
                exportExtension = ".xls";
            }
            else if (reportType == 2)
            {
                exportType = "PDF";
                exportExtension = ".pdf";
            }
            viewer.LocalReport.DataSources.Add(new ReportDataSource("dsReportData", model));
            viewer.LocalReport.EnableHyperlinks = true;
            byte[] bytes = viewer.LocalReport.Render(exportType, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Clear();
            Response.ContentType = mimeType;
            if (id == 1)
            {
                Response.AddHeader("content-disposition", "attachment; filename=fileName1" + exportExtension);
            }
            else if (id == 2)
            {
                Response.AddHeader("content-disposition", "attachment; filename=fileName2" + exportExtension);
            }
            Response.BinaryWrite(bytes);
            Response.End();
            return null;
        }
        finally
        {
            if (viewer != null)
            {
                viewer.Dispose();
                viewer = null;
            }
        }
    }
