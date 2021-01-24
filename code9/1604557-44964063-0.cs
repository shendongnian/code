    public class SuccessfulDependencyFilter : ITelemetryProcessor
      {
    
        private ITelemetryProcessor Next { get; set; }
    
        // You can pass values from .config
        public string MyParamFromConfigFile { get; set; }
    
      // Example: replace with your own modifiers.
        private void ModifyItem (ITelemetry item)
        {
            item.Context.Properties.Add("app-version", "1." + MyParamFromConfigFile);
        }
