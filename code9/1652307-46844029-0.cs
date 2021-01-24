    // This can be used where you don't have access to this.User
    var userName = Thread.CurrentPrincipal.Identity.Name; // Identity has all the claims
    User user = _userRepository.Query(x => x.UserName == userName).FirstOrDefault();
    if (user.Roles.Any(r => r.Name == UserRole.Superadmin.ToString()))
    {
         // Special code for SuperAdmin
    }
