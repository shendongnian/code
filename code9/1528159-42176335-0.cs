    [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<string> Login(LoginViewModel model )
        {                 
                var u = await UserManager.FindByEmailAsync(model.Email);
                bool passhash = false;
                if (u != null)
                {
                  passhash = await UserManager.CheckPasswordAsync(u, model.Password);
                }                
                if (u != null && passhash)
                {
                  await SignInAsync(u, model.RememberMe);                 
                  return ("ok");
                }
                else                
                   return ("Nom d'utilisateur ou mot de passe non valide.");  
        }
