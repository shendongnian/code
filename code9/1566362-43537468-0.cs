    public sealed class EmailOptionsSetter
    {
        readonly string _tooltip;
        readonly string _format;
        readonly bool   _isReadOnly;
        public EmailOptionsSetter(string tooltip, string format, bool isReadOnly)
        {
            _tooltip    = tooltip;
            _format     = format;
            _isReadOnly = isReadOnly;
        }
        public void SetOptions(YourEmailType emailObj, string email)
        {
            emailObj.NavigateUrl = string.Format(_format, email);
            emailObj.Text        = email;
            emailObj.ToolTip     = _tooltip;
            emailObj.Visible     = _isReadOnly;
        }
    }
