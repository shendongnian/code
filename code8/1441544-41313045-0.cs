    private string GenerateActionLink(string actionName, string token, string username) {
        string validationLink = null;
        if (Request.Url != null) {
            validationLink = Url.Action(actionName, "Register",
                new { Token = token, Username = username },
                Request.Url.Scheme);
        }
    
        return validationLink;
    }
