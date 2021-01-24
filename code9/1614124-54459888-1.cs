    // Cast to ClaimsIdentity.
    var identity = HttpContext.User.Identity as ClaimsIdentity;
    
    // Gets list of claims.
    IEnumerable<Claim> claim = identity.Claims; 
    
    // Gets name from claims. Generally it's an email address.
    var usernameClaim = claim
        .Where(x => x.Type == ClaimTypes.Name)
        .FirstOrDefault();
    
    // Finds user.
    var userName = await _userManager
        .FindByNameAsync(usernameClaim.Value);
    
    if (userName == null)
    {
        return BadRequest();
    }
    
    // The rest of your code goes here...
