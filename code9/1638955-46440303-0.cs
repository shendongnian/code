    string reportName = "";
    protected void Page_Load(object sender, EventArgs e)
        {
            this.Mainreport = (StiReport)Session["SelectedReport"];
            this.reportName = (string)Session["ReportName"];
            StiWebViewer1.Report = this.Mainreport;
            StiWebViewer1.DataBind();
            if (!IsPostBack)
            {
                string iQueryString = Request.QueryString["sti_StiWebViewer1_export"];
                if (iQueryString != null) this.SaveFile(iQueryString);
            }
        }
        private void SaveFile(string iQueryString)
        {
            if (this.reportName == null) this.reportName = "Report";
            MemoryStream mes = new MemoryStream();
            HttpContext.Current.Response.Clear();
            switch (iQueryString)
            {
                #region Cases
                case "SaveAdobePdf":
                    {
                        this.Mainreport.ExportDocument(StiExportFormat.Pdf, mes);
                        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + this.reportName + ".Pdf");
                    }
                    break;
                case "SaveMicrosoftXps":
                    {
                        this.Mainreport.ExportDocument(StiExportFormat.Xps, mes);
                        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + this.reportName + ".Xps");
                    }
                    break;
                    #endregion
            }
            mes.WriteTo(Response.OutputStream);
            HttpContext.Current.Response.End();
            mes.Close();
        }
