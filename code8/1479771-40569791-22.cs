        public class UploadController : Controller
        {
            private readonly IFileProvider fileProvider;
    
            public UploadController(IFileProvider fileProvider)
            {
                this.fileProvider = fileProvider;
            }
