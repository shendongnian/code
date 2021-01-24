    <system.diagnostics>
        <sources>
          <source propagateActivity="false" name="System.ServiceModel"
            switchValue="Warning">
            <listeners>
              <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                <filter type="" />
              </add>
              <add name="ServiceModelTraceListener">
                <filter type="" />
              </add>
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add initializeData="traces.svclog" type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelTraceListener" traceOutputOptions="None">
            <filter type="" />
          </add>
        </sharedListeners>
      </system.diagnostics>
