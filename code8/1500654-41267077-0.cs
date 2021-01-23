    public class ScratchController : Controller
    {
        private readonly IProvideFilePath _pathProvider;
        private readonly IProvideCacheSupport _cacheProvider;
        public ScratchController(IProvideFilePath pathProvider, IProvideCacheSupport cacheProvider)
        {
            _pathProvider = pathProvider;
            _cacheProvider = cacheProvider;
        }
        [HttpPost]
        public FileResult Index(string url, List<string> parameters)
        {
            var fileContent = _cacheProvider.GetItem(url) as string;  
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                var filePath = _pathProvider.MapPath(url);
                fileContent = File.ReadAllText(filePath);
                _cacheProvider.AddItem(url, fileContent);
            }
            fileContent = makeChangesToContent(fileContent, parameters);
            return Content(fileContent);
        }
    }
