    [HttpGet("RegisterNewUser")]
    public async Task<HttpResponseMessage> RegisterNewUser([FromBody] NewUserRegistration user) {
        if (ModelState.IsValid) {
            var newUser = new ApplicationUser() {
                UserName = user.username,
                Email = user.password
            };
            var result = await _userManager.CreateAsync(newUser, user.password);
            if (result.Errors.Count() > 0) {
                var errors = new IdentityResultErrorResponse().returnResponseErrors(result.Errors);
                return this.WebApiResponse(errors, HttpStatusCode.BadRequest);
            }
        } else {
            var errors = new ViewModelResultErrorResponse().returnResponseErrors(ModelState);
            return this.WebApiResponse(errors, HttpStatusCode.BadRequest);
        }
        return this.WebApiResponse(
                    "We have sent a valifation email to you, please click on the verify email account link.",
                    HttpStatusCode.OK);
    }
