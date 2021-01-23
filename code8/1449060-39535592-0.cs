    public class FilesController : Controller
    {
        public FileResult GetFile(/*params*/)
        {
            // get fileBytes
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return base.File(fileBytes, contentType, "Download.xlsx");
        }
    }
