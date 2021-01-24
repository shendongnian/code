    [Route("Token")]
    [HttpPost]
    public async Task<IActionResult> CreateToken([FromBody] CredentialViewModel model)
    {
        if (model.GrantType is "refresh_token")
        {
            // Lookup which user is tied to model.RefreshToken
            // Generate access token from the username (no password check required)
            // Return the token (access + expiration)
        }
        else if (model.GrantType is "password")
        {
            if (model.Scopes contains "offline_access")
            {
                // Generate access token
                // Generate refresh token (random GUID + model.username)
                // Persist refresh token
                // Return the complete token (access + refresh + expiration)
            }
            else
            {
                // Generate access token
                // Return the token (access + expiration)
            }
        }
    }
