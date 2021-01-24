    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < validPages.Count; i++)
    {
         builder.Append("<br/>");
         builder.Append(validPages[i]);
         builder.Append("<br/>");  
    }
    ValidLinksBox.Text =  builder.ToString();
    builder = new StringBuilder();
    foreach (string invalidPage in invalidPages)
    {
        builder.Append("<div class=\"alert success\"><p>");
        builder.Append(invalidPage);
        builder.Append("</p></div>");
    }
    InvalidLinksBox.Text = builder.ToString();
