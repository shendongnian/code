    public static IHtmlString RenderAsJson(this HtmlHelper helper, object model)
    {
        var obj = JsonConvert.SerializeObject(model,
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        return helper.Raw(obj);
    }
