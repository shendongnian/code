    public static MvcHtmlString DatabaseImage<TModel>(this HtmlHelper<TModel> htmlHelper, Func<TModel, byte[]> func) {            
        var dastabaseImg = func(htmlHelper.ViewData.Model);
        var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(dastabaseImg));
        return new MvcHtmlString("<img src='" + img + "'  />");
    }
