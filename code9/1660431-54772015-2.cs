    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    namespace Utilities.HttpContext
    {
        public class FakeHttpContextWrapper : IHttpContextWrapper
        {
            public Task SignInAsync(Controller controller, string subject, string name, AuthenticationProperties props)
            {
                return Task.CompletedTask;
            }
        }
    }
