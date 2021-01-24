    public class KendoSortSpecifierBinder : System.Web.Http.ModelBinding.IModelBinder
    {
        private static readonly Regex _sortFieldMatcher;
        private static readonly Regex _sortDirMatcher;
        static KendoSortSpecifierBinder() {
            _sortFieldMatcher = new Regex(@"^sort\[(?<index>\d+)\](\[field\]|\.field)$", RegexOptions.Singleline | RegexOptions.Compiled);
            _sortDirMatcher = new Regex(@"^sort\[(?<index>\d+)\](\[dir\]|\.dir)$", RegexOptions.Singleline | RegexOptions.Compiled);
        }
        public bool BindModel(HttpActionContext actionContext, System.Web.Http.ModelBinding.ModelBindingContext bindingContext) {
            if (bindingContext.ModelType != typeof(KendoSortSpecifier[]))
                return false;
            var request = actionContext.Request;
            var queryString = request.GetQueryNameValuePairs();
            var result = new List<KendoSortSpecifier>();
            foreach (var kv in queryString) {
                var match = _sortFieldMatcher.Match(kv.Key);
                if (match.Success) {
                    var index = int.Parse(match.Groups["index"].Value);
                    while (result.Count <= index) {
                        result.Add(new KendoSortSpecifier());
                    }                                        
                    result[index].Field = kv.Value;
                }
                else {
                    match = _sortDirMatcher.Match(kv.Key);
                    if (match.Success) {
                        var index = int.Parse(match.Groups["index"].Value);
                        while (result.Count <= index) {
                            result.Add(new KendoSortSpecifier());
                        }
                        result[index].Direction = kv.Value;
                    }
                }
            }
            bindingContext.Model = result.ToArray();
            return true;
        }
    }
