    HtmlGenericControl ul = new HtmlGenericControl("ul");
    var li = new HtmlGenericControl("li");
    var img = new HtmlGenericControl("img");
    img.Attributes.Add("src", "url");
    li.Controls.Add(img);
    ul.Controls.Add(li);
