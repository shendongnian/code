    var helloTemplate = "Hello @Model.Name";
    string result;
    var model = new { Name = "World" };
    //Has the template already been used? If so, Run without compilation is faster
    if(Engine.Razor.IsTemplateCached("helloTemplate", null))
    {
        result = Engine.Razor.Run("helloTemplate", null, model);
    }
    else
    {
        result = Engine.Razor.RunCompile(helloTemplate, "helloTemplate", null, model);
    }
