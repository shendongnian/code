    public class UploadFileModel 
    {
        public UploadFileModel()
        {
            Files = new List<HttpPostedFileBase>();
        }
    
        public List<HttpPostedFileBase> Files { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
