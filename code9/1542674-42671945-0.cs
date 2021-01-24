    public class FileDownloadResult : ContentResult
    {
        private string fileName;
        private Stream fileData;
        private bool downloadFlag;
        public FileDownloadResult(string fileName, Stream fileData, bool downloadFlag)
        {
            this.fileName = fileName;
            this.fileData = fileData;
            this.downloadFlag = downloadFlag;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (string.IsNullOrEmpty(this.fileName))
                throw new Exception("A file name is required.");
            if (this.fileData == null)
                throw new Exception("File data is required.");
            var contentDisposition = "";
            if (!downloadFlag)
                contentDisposition = string.Format("inline; filename={0}", this.fileName);
            else
                contentDisposition = string.Format("attachment; filename={0}", this.fileName);
            context.HttpContext.Response.AddHeader("Content-Disposition", contentDisposition);
            if (downloadFlag)
                ContentType = "application/force-download";
            else
            {
                if (this.fileName.IndexOf(".pdf", fileName.IndexOf(".")) > 0)
                    ContentType = "application/pdf";
                else if (this.fileName.IndexOf(".csv", fileName.IndexOf(".")) > 0)
                    ContentType = "application/csv";
                else if (this.fileName.IndexOf(".xls", fileName.IndexOf(".")) > 0)
                    ContentType = "application/xls";
                else if (this.fileName.IndexOf(".xlsx", fileName.IndexOf(".")) > 0)
                    ContentType = "application/xslx";
                else
                    ContentType = "application/txt";
            }
            context.HttpContext.Response.AddHeader("Content-Type", ContentType);
            byte[] buffer = new byte[1024];
            int count = 0;
            while ((count = fileData.Read(buffer, 0, buffer.Length)) > 0)
            {
                context.HttpContext.Response.OutputStream.Write(buffer, 0, count);
                context.HttpContext.Response.Flush();
            }
        }
    }
