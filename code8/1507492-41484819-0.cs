    void Function1(string value)
    {
        var messageRows = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder builder = new StringBuilder();
        foreach (string oneRow in messageRows)
        {
            builder.Append(Server.HtmlEncode(oneRow) + "<br />");
        }
        p1.InnerHtml = builder.ToString();
    }
