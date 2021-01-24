    public class UserTelemetryIntitializer : ITelemetryInitializer
    {
        public void Initialize(Microsoft.ApplicationInsights.Channel.ITelemetry telemetry)
        {
            var context = HttpContext.Current;
            if (context == null)
                return;
            // If user has authenticated, add a property UserID to telemetry which will have
            //  * domain\\username for Windows Authentication
            //  * username@domain.com for Azure AD Authentication
            if (context.User.Identity.IsAuthenticated)
                telemetry.Context.Properties["UserID"] = context.User.Identity.Name;
            else
                telemetry.Context.Properties["UserID"] = "Null";
        }
    }
