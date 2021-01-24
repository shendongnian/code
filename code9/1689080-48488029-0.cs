    using System.IO;
    using System.Reflection;
    using System.Web.Hosting;
    using System.Web.Http;
    public class MyApiController : ApiController
    {
        public string Get()
        {
            var relative = "Views/templates/test.cshtml";
            var abosolute = "";
            if (HostingEnvironment.IsHosted)
                abosolute = HostingEnvironment.MapPath(string.Format("~/{0}", relative));
            else
            {
                var root = new DirectoryInfo(Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location)).Parent.FullName;
                abosolute = Path.Combine(root, relative.Replace("/", @"\"));
            }
            return System.IO.File.ReadAllText(abosolute);
        }
    }
