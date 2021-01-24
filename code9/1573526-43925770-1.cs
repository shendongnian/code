    <ApplicationInsights>
      <TelemetryInitializers>
        <!-- Fully qualified type name, assembly name: -->
        <Add Type="MvcWebApp.Telemetry.UserTelemetryIntitializer, MvcWebApp"/>
        ...
      </TelemetryInitializers>
    </ApplicationInsights>
