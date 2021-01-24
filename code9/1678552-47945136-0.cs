    public class MyController : Controller
    {
        [HttpPost]
        [Route("DownloadFiles/{company_id}")]
        public void DownloadFiles(Int64 company_id, TasksFilterModel searchModel)
        {
             var files = ...;
             ZipFilesToResponse(HttpContext.Response, files, "download.zip");
        }
    }
