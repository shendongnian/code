    public ActionResult ClientLogin(ClientLoginViewModel model)
    {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var serviceOrder = Repository.ServiceOrders
                .Where(so => so.IsActive && so.Vehicle.LicensePlate == model.LicensePlate &&
                so.Client.Document.Replace(".", "").Replace("-", "").Replace("/", "").Substring(0, 6) == model.Password)
                .OrderByDescending(so => so.CreatedAt).FirstOrDefault();
            if (serviceOrder != null)
            {
                try
                {
                    var identity = new ClaimsIdentity(
                        new[]
                        {
                            // adding following 2 claims just for supporting default antiforgery provider
                            new Claim(ClaimTypes.NameIdentifier, "AnonymousUserID"),
                            new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                            new Claim(ClaimTypes.Name, serviceOrder.Client.Name),
                            new Claim(ClaimTypes.Role, AppRoleClaims.Client),
                            new Claim(AppAccessClaims.ClientScreenAccess, AppAccessClaimsValues.Visualize) 
                        },
                        DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignIn(
                       new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
                    return Redirect("/cliente/consultarveiculo");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Tentativa de login inválida. - " + ex.Message);
                    return View(model);
                }
            }
            ModelState.AddModelError("", "Tentativa de login inválida. - Nenhum cliente com a placa e a senha informada.");
            return View(model);
      }
