    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    namespace Utilities.HttpContext
    {
        public class DefaultHttpContextWrapper : IHttpContextWrapper
        {
            public async Task SignInAsync(Controller controller, string subject, string name, AuthenticationProperties props)
            {
                await controller.HttpContext.SignInAsync(subject, name, props);
            }
        }
    }
