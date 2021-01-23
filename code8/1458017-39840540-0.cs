    protected void Page_Load(object sender, EventArgs e)
    {
        // The query string is automatically decoded
        var src = this.Request.QueryString["Image"]; 
        this.Img2.Src = validInput(src);
    }
    protected string validInput(string input)
    {
        var regex = "[\'<>\"]";
        if (null != input && !input.Contains("\"") && input.StartsWith("/"))
        {
            return !Regex.IsMatch(input, regex) ? AntiXssEncoder.XmlAttributeEncode(input):string.Empty;
        }
        return string.Empty;
    }
