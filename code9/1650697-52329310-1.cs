    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using System;
    /// <summary>
    /// The extension methods that extends <see cref="IApplicationBuilder" /> for authentication purposes
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Requires authentication for paths that starts with <paramref name="pathPrefix" />
        /// </summary>
        /// <param name="app">The application builder</param>
        /// <param name="pathPrefix">The path prefix</param>
        /// <returns>The application builder</returns>
        public static IApplicationBuilder RequireAuthenticationOn(this IApplicationBuilder app, string pathPrefix)
        {
            return app.Use((context, next) =>
            {
                // First check if the current path is the swagger path
                if (context.Request.Path.HasValue && context.Request.Path.Value.StartsWith(pathPrefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    // Secondly check if the current user is authenticated
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        return context.ChallengeAsync();
                    }
                }
                return next();
            });
        }
    }
