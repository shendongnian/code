    public virtual Task CreateAsync(User user)
    {
        using (var _conn = new SqlConnection(_dbConn))
        {
            var result = _conn.ExecuteAsync("users_UserCreate", new
                        {
                            @UserId = user.Id,
                            @UserName = user.UserName,
                            @PasswordHash = user.PasswordHash,
                            @SecurityStamp = user.SecurityStamp
                        }, commandType: CommandType.StoredProcedure).ConfigureAwait(true);
            
            return Task.FromResult(result);
        }
    }
