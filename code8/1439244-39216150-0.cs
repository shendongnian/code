    public class ScriptWrapper : IDisposable
    {
        private HtmlHelper _helper;
        private string _originalString;
        private StringBuilder _sb;
    
        public ScriptWrapper(HtmlHelper helper)
        {
            _helper = helper;
            _sb = ((StringWriter) _helper.ViewContext.Writer).GetStringBuilder();
            _originalString = _sb.ToString();
            _sb.Clear();
        }
    
        public void Dispose()
        {
            var contents = _sb.ToString();
            _sb.Clear();
            _sb.Append(_originalString);
        }
    }
