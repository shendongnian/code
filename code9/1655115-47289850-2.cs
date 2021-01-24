    public interface ISecureClientSecret
    {
        /// <summary>
        /// Writes SecureString to the dictionary.
        /// </summary>
        /// <param name="parameters"></param>
        void ApplyTo(IDictionary<string, string> parameters);
        
        /// <summary>
        /// Indicates whether this <see cref="ISecureClientSecret"/> has already been applied.
        /// </summary>
        /// <returns><c>true</c> if applied, otherwise <c>false</c></returns>
        bool IsApplied;
    }
