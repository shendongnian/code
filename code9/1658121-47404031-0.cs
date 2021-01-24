    // GET: Language
        public ActionResult Change(string lang)
        {
            if(lang != null)
            {
                if(User.Identity.IsAuthenticated)
                {
                    var claims = new List<Claim>();
                    ApplicationDbContext mycontext = new ApplicationDbContext();
                    UserStore<ApplicationUser> mystore = new UserStore<ApplicationUser>(mycontext);
                    ApplicationUserManager UserMan = new ApplicationUserManager(mystore);
                    ApplicationUser _user = UserMan.FindById(User.Identity.GetUserId());
                    var claim = _user.Claims.FirstOrDefault(c => c.ClaimType == "Language");
                 
                    if (claim != null) // User have Language claim the table 
                    {
                        if (claim.ClaimValue != lang) // and chosen language doesn't match it
                        {
                            UserMan.RemoveClaim(User.Identity.GetUserId(), new Claim("Language", claim.ClaimValue));
                            UserMan.AddClaimAsync(User.Identity.GetUserId(), new Claim("Language", lang)); 
                        }
                    }
                    else if(claim == null)
                    {
                        UserMan.AddClaimAsync(User.Identity.GetUserId(), new Claim("Language", lang));
                    }
                }
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = lang;
                Response.Cookies.Add(cookie);
                return Redirect(Request.UrlReferrer.ToString());
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
