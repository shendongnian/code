    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            //prevent running of duplicate tasks.
            if(context.Session[SESSIONKEY]!=null && ((Task<int>)context.Session[SESSIONKEY]).IsCompleted==false) return;
            var tcs = new TaskCompletionSource<int>();
            Task.Run(async () =>
            {
                LogUtil.LogInfo("Getting data");
                FillReportTable();
                LogUtil.LogInfo("File upload is disabled");
                string IOPath = Server.MapPath("~/Report-" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".xlsx");
                if (System.IO.File.Exists(IOPath))
                {
                    System.IO.File.Delete(IOPath);
                }
                System.IO.File.Copy(Server.MapPath("~/TempReport.xlsx"), IOPath);
                ExportDSToExcel(IOPath);
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["ftpUpload"].ToString()))
                {
                    UploadToFTP(IOPath);
                }
                else
                {
                    LogUtil.LogInfo("File upload is disabled");
                }
                tcs.SetResult(1);
            });
            context.Session[SESSIONKEY] = tcs.Task;
            lblMessage.Text = "File uploaded started";
    }
