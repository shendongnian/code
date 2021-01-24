        protected void Page_Load(object sender, EventArgs e)
        {
            var reportFolderPath = Server.MapPath("~/Reports"); //change the "~/Reports" to your report folder name
            IEnumerable<string> xmlFiles = Directory.GetFiles(reportFolderPath, "*.xml");
            //As a common practice server file path should not be shown to the client, use file name instead
            xmlFiles = xmlFiles.Select(o => Path.GetFileNameWithoutExtension(o)).Where(o => o.Contains("Arun"));;
            ddlReportTemplate.DataSource = xmlFiles;
            ddlReportTemplate.DataBind();
        }
