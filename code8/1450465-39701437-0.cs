    /// <summary>
    ///     Stores a user's security stamp
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IUserSecurityStampStore<TUser, in TKey> : IUserStore<TUser, TKey> where TUser : class, IUser<TKey>
    {
        /// <summary>
        ///     Set the security stamp for the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="stamp"></param>
        /// <returns></returns>
        Task SetSecurityStampAsync(TUser user, string stamp);
        /// <summary>
        ///     Get the user security stamp
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> GetSecurityStampAsync(TUser user);
    }
