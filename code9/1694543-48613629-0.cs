        public async Task<string> UploadFile()
        {
            if (!(await HttpContext.AuthenticateAsync()).Succeeded)
            {
                HttpContext.Response.StatusCode = 401; //Unauthorized
                HttpContext.Response.Headers.Add("Content-Length", "0");
                HttpContext.Response.Body.Flush();
                HttpContext.Abort();
                return null;
            }
            ...
        }
