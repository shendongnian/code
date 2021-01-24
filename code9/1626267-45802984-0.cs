    public class RealUserIDTelemetryInitializer:ITelemetryInitializer
    {
         private readonly Func<string> usernameProvider; 
         public RealUserIDTelemetryInitializer(Func<string> usernameProvider)
         {
             this.usernameProvider = usernameProvider;
         }
         public void Initialize(Microsoft.ApplicationInsights.Channel.ITelemetry telemetry)
         {
               telemetry.Context.User.Id = usernameProvider.Invoke();
         }
    }
