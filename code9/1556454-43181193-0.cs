    StringBuilder builder = new StringBuilder();
    foreach (string invalidPage in invalidPages)
    {
        builder.Append("<div class=\"alert success\"><p>");
        builder.Append(invalidPage);
        builder.Append("</p></div>");
    }
    InvalidLinksBox.Text = builder.ToString();
   
