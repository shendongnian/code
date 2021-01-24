To do so, you can add `ContentWithVersion` extension method to the existing `UrlHelper`:
using System.IO;
using System.Web;
using System.Web.Mvc;
public static class UrlHelperExtensions
{
    public static string ContentWithVersion(this UrlHelper urlHelper, string path)
    {
        var result = urlHelper.Content(path);
        var file = HttpContext.Current.Server.MapPath(path);
        if (File.Exists(file))
        {
            result += $"?v={File.GetLastWriteTime(file).ToString("yyyyMMddHHmmss")}";
        }
        return result;
    }
}
