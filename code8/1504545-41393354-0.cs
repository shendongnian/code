    public class ServeFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            byte[] fileBytes = File.ReadAllBytes("c:\\path\\to\\folder\\with\\files\\" + context.Request.QueryString["fileName"]);
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=PSL.xlsx");
            context.Response.BinaryWrite(fileBytes);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
