    NameValueCollection FormFields = new NameValueCollection();
            FormFields.Add("abc", obj1);
            FormFields.Add("xyz", obj2);
         Response.Clear();
        Response.Write("<html><head>");
        Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
        Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
        for (int i = 0; i < FormFields.Keys.Count; i++)
        {
            Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", FormFields.Keys[i], FormFields[FormFields.Keys[i]]));
        }
        Response.Write("</form>");
        Response.Write("</body></html>");
        Response.End();
