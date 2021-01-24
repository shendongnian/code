    public static class ScriptHtmlHelper
    {
        private const string ScriptsKey = "__ScriptHtmlHelper_Scripts";
        public static ScriptBlock BeginScripts(this IHtmlHelper helper)
        {
            return new ScriptBlock(helper.ViewContext);
        }
        public static IHtmlContent PageScripts(this IHtmlHelper helper)
        {
            if (helper.ViewContext.HttpContext.Items.TryGetValue(ScriptsKey, out var scriptsData) && scriptsData is List<object> scripts)
                return new HtmlContentBuilder(scripts);
            return HtmlString.Empty;
        }
        public class ScriptBlock : IDisposable
        {
            private ViewContext _viewContext;
            private TextWriter _originalWriter;
            private StringWriter _scriptWriter;
            private bool _disposed;
            public ScriptBlock(ViewContext viewContext)
            {
                _viewContext = viewContext;
                _originalWriter = viewContext.Writer;
                // replace writer
                viewContext.Writer = _scriptWriter = new StringWriter();
            }
            public void Dispose()
            {
                if (_disposed)
                    return;
                try
                {
                    List<object> scripts = null;
                    if (_viewContext.HttpContext.Items.TryGetValue(ScriptsKey, out var scriptsData))
                        scripts = scriptsData as List<object>;
                    if (scripts == null)
                        _viewContext.HttpContext.Items[ScriptsKey] = scripts = new List<object>();
                    scripts.Add(new HtmlString(_scriptWriter.ToString()));
                }
                finally
                {
                    // restore the original writer
                    _viewContext.Writer = _originalWriter;
                    _disposed = true;
                }
            }
        }
    }
