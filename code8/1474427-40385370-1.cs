    htmlGenericControl input = new HtmlGenericControl("input");
    input.Attributes.Add("type", "radio");
    input.Attributes.Add("name", "slide_switch");
    input.Attributes.Add("id", string.Format("projectImage-{0}", item.ProjectImageId));
    Slider.Controls.Add(input);
