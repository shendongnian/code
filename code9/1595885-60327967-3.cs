To do so, you can add `ContentWithVersion` extension method to the existing [`UrlHelper`](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.urlhelper?view=aspnet-mvc-5.2):
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
public static class UrlHelperExtensions
{
    public static string ContentWithVersion(this UrlHelper urlHelper, string path)
    {
        if (urlHelper == null)
            throw new ArgumentNullException(nameof(urlHelper));
        var result = urlHelper.Content(path);
        var file = HttpContext.Current.Server.MapPath(path);
        if (File.Exists(file))
            result += $"?v={File.GetLastWriteTime(file).ToString("yyyyMMddHHmmss")}";
        return result;
    }
}
