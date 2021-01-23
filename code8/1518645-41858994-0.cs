    NameValueCollection qscoll = HttpUtility.ParseQueryString(querystring);
    StringBuilder sb = new StringBuilder("<br />");
    foreach (String s in qscoll.AllKeys)
    {
        sb.Append(s + " - " + qscoll[s] + "<br />");
    }
    ParseOutput.Text = sb.ToString();
