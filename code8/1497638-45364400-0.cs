    var ConfirmLink = Url.Action(
        "ConfirmEmail",
        "Account",
        new { userId = user.Id, code },
        HttpContext.Request.Scheme,
        HttpContext.Request.Host.Value //HttpContext.Request.Host.ToString()
    )
