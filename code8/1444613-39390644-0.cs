    public class HomeController : Controller
    {        
        public ActionResult Download(string id)
        {
            byte[] fileInBytes = GetFileDataFromDatabase(id);
            return File(fileInBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                id + ".docx");
        }
        private byte[] GetFileDataFromDatabase(string id)
        {
            // your code to access the data layer
            return byteArray;
        }
    }
