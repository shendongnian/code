    using System.Web;
    namespace ResourceManager
    {
        public class ResourceManager : IResourceManager
        {
            public string GetError(string key)
            {
                return HttpContext.GetGlobalResourceObject("Errors", key).ToString();
            }
            //And so on........
        }
    }
