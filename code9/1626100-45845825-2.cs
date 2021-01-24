    /// <summary>
    ///     Find a user by email
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public static TUser FindByEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, string email)
        where TKey : IEquatable<TKey>
        where TUser : class, IUser<TKey>
    {
        if (manager == null)
        {
            throw new ArgumentNullException("manager");
        }
        return AsyncHelper.RunSync(() => manager.FindByEmailAsync(email));
    }
