        [Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("MyOwnCookieName");
            return RedirectToAction("Index");
        }
