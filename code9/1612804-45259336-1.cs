        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            Response.Cookies.Delete(".AspNetCore.ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
