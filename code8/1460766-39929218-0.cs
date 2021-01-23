    namespace System.Security.Principal
    {
        //
        // Summary:
        //     Defines the basic functionality of an identity object.
        public interface IIdentity
        {
            //
            // Summary:
            //     Gets the type of authentication used.
            //
            // Returns:
            //     The type of authentication used to identify the user.
            string AuthenticationType { get; }
            //
            // Summary:
            //     Gets a value that indicates whether the user has been authenticated.
            //
            // Returns:
            //     true if the user was authenticated; otherwise, false.
            bool IsAuthenticated { get; }
            //
            // Summary:
            //     Gets the name of the current user.
            //
            // Returns:
            //     The name of the user on whose behalf the code is running.
            string Name { get; }
        }
    }
