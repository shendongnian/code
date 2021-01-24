     @{ 
        dynamic obj = new ExpandoObject();
        if (Model.IsRequired)
        {
            obj.required = "required";
        }
        obj.style = "width:220px";
    }
    @(Html.Kendo().TextBoxFor(m => m.Value)
            .Enable(!Model.IsDisabled)
            .Value(Model.DefaultValue)
            .HtmlAttributes(obj)
            .Name(Model.Name))
