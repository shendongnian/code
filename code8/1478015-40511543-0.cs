    public static class UserManagerExtensions 
    {
        public static Task<TUser> IsUserActiveAsync(this UserManager mgr, Guid userId)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var param = new DynamicParameters();
                param.Add("@UserId", userId);
                var result = connection.Query<TUser>("IdentityCheckUserIsActive", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return Task.FromResult(result);
            }
        }
    }
