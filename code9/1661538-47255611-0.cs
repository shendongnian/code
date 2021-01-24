    private enum UserRoles
    {
       None = 0,
       User,
       Admin
    }
    private struct LoginResult
    {
       bool IsValid = false;
       UserRole Role = UserRoles.None;
    }
