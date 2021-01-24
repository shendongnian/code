    public class PrincipalProvider : IPrincipalProvider
    {
        // Readonly fields
        private readonly HttpContext _current;
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrincipalProvider()
        {
            _current = HttpContext.Current;
        }
        /// <summary>
        /// Gets the current user
        /// </summary>
        public IPrincipal User => _current?.User;
    }
