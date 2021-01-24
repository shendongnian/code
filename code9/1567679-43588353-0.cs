    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
      </startup>
      <!--diagnostics traces will be found in Web_messages.svclog file and Web_tracelog.svclog file-->
      <system.diagnostics>
        <sources>
          <source name="System.ServiceModel.MessageLogging" switchValue="Warning, ActivityTracing">
            <listeners>
              <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                <filter type="" />
              </add>
              <add name="ServiceModelMessageLoggingListener">
                <filter type="" />
              </add>
            </listeners>
          </source>
          <source name="System.ServiceModel" switchValue="Warning,ActivityTracing"
            propagateActivity="true">
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
          <add initializeData="Web_messages.svclog" type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelMessageLoggingListener" traceOutputOptions="Timestamp">
            <filter type="" />
          </add>
          <add initializeData="Web_tracelog.svclog" type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelTraceListener" traceOutputOptions="Timestamp">
            <filter type="" />
          </add>
        </sharedListeners>
        <trace autoflush="true" />
      </system.diagnostics>
      <system.serviceModel>
        <!--Enable diagnostics to record wcf communication-->
        <diagnostics wmiProviderEnabled="true">
          <messageLogging logEntireMessage="true" logMalformedMessages="true" logMessagesAtServiceLevel="true" logMessagesAtTransportLevel="true" />
        </diagnostics>
        <bindings>
          <basicHttpsBinding>
            <binding name="HttpsBasicBinding">
              <security mode="Transport" >
                <transport clientCredentialType="Certificate"/>
              </security>
            </binding>
          </basicHttpsBinding>
        </bindings>
        <client>
          <endpoint
             name ="gms_endpoint"
             address="https://aaa.bbb.eu/"
             binding="basicHttpsBinding"
             bindingConfiguration="HttpsBasicBinding"
             contract="SomeNamespace.IncidentBrokerPortType"
             behaviorConfiguration="GmsBehavior"
          />
        </client>
        <behaviors>
          <endpointBehaviors>
            <behavior name="GmsBehavior">
              <clientCredentials>
                <clientCertificate x509FindType="FindByThumbprint"
    findValue="5c1dd5c93d1854cb2d698451e1d2a78a3d94dcb0"
    storeLocation="LocalMachine"/>
              </clientCredentials>
            </behavior>
          </endpointBehaviors>
        </behaviors>
      </system.serviceModel>
    </configuration>
