        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }
        [HttpPost]
        public IActionResult Index([FromBody]LoginModel model)
        {
            if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
            {
                if (UserSystem.Login(model.Username, model.Password, model.RememberMe, HttpContext))
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Accepted;
                    return Json(new
                    {
                        returnUrl = "/admin/dashboard"
                    });
                }
            }
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Json(new
            {
                error = "Username and/or password do not match"
            });
        }
