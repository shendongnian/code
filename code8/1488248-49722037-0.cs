    public static class OAuthBearerAuthenticationExtensions
      {
        public static IAppBuilder UseOAuthBearerAuthentication(this IAppBuilder app, OAuthBearerAuthenticationOptions options)
        {
          if (app == null)
            throw new ArgumentNullException(nameof (app));
          app.Use((object) typeof (OAuthBearerAuthenticationMiddleware), (object) app, (object) options);
          app.UseStageMarker(PipelineStage.Authenticate);
          return app;
        }
      }
