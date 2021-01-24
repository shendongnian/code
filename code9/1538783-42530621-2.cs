    public string GetImageUrl(string baseUrlFromConfig, string imageFileName)
    {
        // Get request object
        var request = HttpContext.Current.Request;
        // Generate base application url
        var appBaseUrl = !string.IsNullOrWhiteSpace(baseUrlFromConfig)
            ? baseUrlFromConfig
            : string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, Url.Content("~"));
        // Generate full image url
        var imageUrl = string.Format("{0}/Images/{1}", appBaseUrl, imageFileName);
        return imageUrl;
    }
