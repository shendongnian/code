     var identity = HttpContext.User.Identity as ClaimsIdentity;//cast to claimsidentity
     IEnumerable<Claim> claim = identity.Claims; 
    //get name from claims,generally it's email address
     var usernameClaim = claim.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
    //find user
                 var userName = await _userManager.FindByNameAsync(usernameClaim.Value);
                 if (userName == null)
             return BadRequest();
                 else 
        //your code goes here
