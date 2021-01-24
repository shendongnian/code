    [HttpPost]
    [AllowAnonymous]
    [Route("api/authentication/FacebookLogin")]
    public async Task<IActionResult> FacebookLogin([FromBody] FacebookToken facebookToken)
    {
        //check token
        var httpClient = new HttpClient { BaseAddress = new Uri("https://graph.facebook.com/v2.9/") };
        var response = await httpClient.GetAsync($"me?access_token={facebookToken.Token}&fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale,picture");
        if (!response.IsSuccessStatusCode) return BadRequest();
        var result = await response.Content.ReadAsStringAsync();
        var facebookAccount = JsonConvert.DeserializeObject<FacebookAccount>(result);
        //register if required
        var facebookUser = _context.FacebookUsers.SingleOrDefault(x => x.Id == facebookAccount.Id);
        if (facebookUser == null)
        {
            var user = new ApplicationUser {UserName = facebookAccount.Name, Email = facebookAccount.Email};
            var result2 = await _userManager.CreateAsync(user);
            if (!result2.Succeeded) return BadRequest();
            facebookUser = new FacebookUser {Id = facebookAccount.Id, UserId = user.Id};
            _context.FacebookUsers.Add(facebookUser);
            _context.SaveChanges();
        }
        //send bearer token
        return Ok(GetToken(facebookUser.UserId));
    }
