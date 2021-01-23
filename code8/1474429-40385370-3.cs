    htmlGenericControl input = new HtmlGenericControl("input");
    input.Attributes.Add("type", "radio");
    input.Attributes.Add("name", "slide_switch");
    input.ID = string.Format("projectImage-{0}", item.ProjectImageId);
    Slider.Controls.Add(input);
