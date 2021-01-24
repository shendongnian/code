    HtmlButton hb = new HtmlButton();
    hb.ServerClick += Button1_Click;
    hb.Attributes.Add("class", "btn blue");
    hb.InnerHtml = "<i class=\"fa fa-check\"></i>Save";
    PlaceHolder1.Controls.Add(hb);
