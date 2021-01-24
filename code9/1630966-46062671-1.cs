    using System.Web.Http.Filters;
    namespace App.Extensions
    {
        public class TestLinkAttribute : ActionFilterAttribute
        {
            public string Path { get; set; }
        }
    }
