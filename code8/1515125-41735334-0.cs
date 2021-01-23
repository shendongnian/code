    System.Web.UI.LiteralControl ltr = new System.Web.UI.LiteralControl();
    StringBuilder sb = new StringBuilder();
    sb.Append("<style type=\"text/css\" rel=\"stylesheet\"> .m-quick-links ul li a:before { background-image: url(");
    sb.Append(FirstLinkIcon); //here i am appending property value in css style
    sb.Append(") !important; } </style>");
    ltr.Text = sb.ToString();
    this.Page.Header.Controls.Add(ltr);
