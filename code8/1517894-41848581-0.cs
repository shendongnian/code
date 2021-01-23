    public static string GetExternalUrl(this Url url)
    {
        var content = UrlResolver.Service.Route(new UrlBuilder(url));
    
        return GetExternalUrl(content);
    }
    public static string GetExternalUrl(this ContentReference contentReference)
    {
        if (ContentReference.IsNullOrEmpty(contentReference)) return null;
    
        var content = ServiceLocator.Current.GetInstance<IContentLoader>().Get<IContent>(contentReference);
    
        return GetExternalUrl(content);
    }
    public static string GetExternalUrl(this IContent content)
    {
        var externalProperty = content?.Property["PageExternalURL"];
    
        return !string.IsNullOrWhiteSpace(externalProperty?.ToString()) ? $"/{externalProperty.ToString().Trim('/')}/" : null;
    }
  
