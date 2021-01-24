    public class UrlHelperService
    {
        private IOptions<CssOptions> _cssOptions;
        private IOptions<JavaScriptOptions> _jsOptions;
        private IUrlHelper _urlHelper;
        public UrlHelperService(
            IOptions<CssOptions> cssOptions,
            IOptions<JavaScriptOptions> jsOptions,
            IUrlHelper urlHelper)
        {
            _cssOptions = cssOptions;
            _jsOptions = jsOptions;
            _urlHelper = urlHelper;
        }
        public string JavaScript(string contentPath)
        {
            if (_jsOptions.Value != null && _jsOptions.Value.Minify)
            {
                contentPath = Path.ChangeExtension(contentPath, ".min.js");
            }
            return _urlHelper.Content(contentPath);
        }
        public string Css(string contentPath)
        {
            if (_cssOptions.Value != null && _cssOptions.Value.Minify)
            {
                contentPath = Path.ChangeExtension(contentPath, ".min.css");
            }
            return _urlHelper.Content(contentPath);
        }
    }
