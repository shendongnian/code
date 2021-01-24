    public class UrlHelperService
    {
        public UrlHelperService(
            IOptions<LessOptions> lessOptions,
            IOptions<TypeScriptOptions> tsOptions,
            IUrlHelper urlHelper) 
        {
            _lessOptions = lessOptions;
            _tsOptions = tsOptions;
            _urlHelper = urlHelper;
        }
        public static string JavaScript(string contentPath)
        {
            if (_tsOptions.Value != null && _tsOptions.Value.Minify)
            {
                contentPath = Path.ChangeExtension(contentPath, ".min.js");
            }
            return _helper.Content(contentPath);
        }
    
        public static string Css(string contentPath)
        {
            if (_lessOptions.Value != null && _lessOptions.Value.Minify)
            {
                contentPath = Path.ChangeExtension(contentPath, ".min.css");
            }
            return _helper.Content(contentPath);
        }
    }
