    /// <summary>
    /// Generates a URL with an absolute path for the specified route <paramref name="routeName"/> and route
    /// <paramref name="values"/>, which contains the specified <paramref name="protocol"/> to use.
    /// </summary>
    /// <param name="helper">The <see cref="IUrlHelper"/>.</param>
    /// <param name="routeName">The name of the route that is used to generate URL.</param>
    /// <param name="values">An object that contains route values.</param>
    /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
    /// <returns>The generated URL.</returns>
    public static string RouteUrl(
        this IUrlHelper helper,
        string routeName,
        object values,
        string protocol)
    {
        if (helper == null)
        {
            throw new ArgumentNullException(nameof(helper));
        }
        return helper.RouteUrl(routeName, values, protocol, host: null, fragment: null);
    }
