     [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
     public ActionResult Index()
        {
            var user = User.FindFirst("Name").Value;
            //or if u want the list of claims
            var claims = User.Claims;
            
            return View();
        }
