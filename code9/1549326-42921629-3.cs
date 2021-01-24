    [AllowAnonymous]
            public async Task<ActionResult> ConfirmEmail(string userId, string code)
            {
                if (userId == null || code == null)
                    return View("Error");             
                var result = await UserManager.ConfirmEmailAsync(userId, code);
                return View(result.Succeeded ? "ConfirmEmail" : "Error");
            }
