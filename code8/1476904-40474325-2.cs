    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        public ExtendedRazorViewEngine()
        {
            List<string> existingPaths = new List<string>(ViewLocationFormats);
            existingPaths.Add("~/Views/Admin/Users/{0}.cshtml");
            ViewLocationFormats = existingPaths.ToArray();
        }
    }
