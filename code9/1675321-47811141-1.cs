    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
      </configSections>
      <!--Start of System Diagnostics-->
      <system.diagnostics>
        <sources>
          <source propagateActivity="true" name="System.ServiceModel" switchValue="Off,ActivityTracing">
            <listeners>
              <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                <filter type="" />
              </add>
              <add name="ServiceModelTraceListener">
                <filter type="" />
              </add>
            </listeners>
          </source>
          <source name="System.ServiceModel.MessageLogging" switchValue="Verbose,ActivityTracing">
            <listeners>
              <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                <filter type="" />
              </add>
              <add name="ServiceModelMessageLoggingListener">
                <filter type="" />
              </add>
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="NewListener" traceOutputOptions="LogicalOperationStack, DateTime, Timestamp, ProcessId, ThreadId, Callstack">
            <filter type="" />
          </add>
          <add initializeData="E:\Projects\C#\home-intranet-webservice\HomeIntranetService\Web_messages.svclog"
            type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelMessageLoggingListener" traceOutputOptions="Timestamp">
            <filter type="" />
          </add>
          <add initializeData="E:\Projects\C#\home-intranet-webservice\HomeIntranetService\Web_tracelog.svclog"
            type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            name="ServiceModelTraceListener" traceOutputOptions="Timestamp">
            <filter type="" />
          </add>
        </sharedListeners>
      </system.diagnostics>
      <!--End System Diagnostic Settings-->
      <appSettings>
        <add key="Images" value="E:\Projects\Web\home-intranet-website\img"/>
        <add key="PageFragments" value="E:\Projects\Web\home-intranet-website\PageFragments"/>
        <add key="aspnet:UseTaskFriendlySynchronizationContext" value="true"/>
      </appSettings>
      <system.web>
        <compilation debug="true" targetFramework="4.6.2"/>
        <httpRuntime targetFramework="4.6.2"/>
      </system.web>
      <system.serviceModel>
        <diagnostics>
          <messageLogging logEntireMessage="true" logKnownPii="true" logMalformedMessages="false"
            logMessagesAtServiceLevel="false" logMessagesAtTransportLevel="false" />
          <endToEndTracing propagateActivity="true" activityTracing="true"
            messageFlowTracing="true" />
        </diagnostics>
        <standardEndpoints>
          <webHttpEndpoint>
            <standardEndpoint name="Documentation" helpEnabled="true"/>
          </webHttpEndpoint>
        </standardEndpoints>
        <bindings>
          <webHttpBinding>
            <binding name="webHttpTransportSecurity">
              <security mode="None"/>
            </binding>
          </webHttpBinding>
        </bindings>
        <services>
          <service name="HomeIntranetService.Services.ComputersAndLicences">
            <endpoint address="../ComputersAndLicences.svc" behaviorConfiguration="webBehaviour"
              binding="webHttpBinding" bindingConfiguration="" contract="HomeIntranetService.Interfaces.IComputersAndLicences"
              kind="webHttpEndpoint" endpointConfiguration="Documentation" />
          </service>
        </services>
        <behaviors>      
          <serviceBehaviors>     
            <behavior>
              <!-- To avoid disclosing metadata information, set the values below to false before deployment -->
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
              <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
              <serviceDebug includeExceptionDetailInFaults="true"/>
            </behavior>
          </serviceBehaviors>
          <endpointBehaviors>
            <behavior name="webBehaviour">
              <webHttp/>
            </behavior>
          </endpointBehaviors>
        </behaviors>
        <protocolMapping>
            <add binding="basicHttpsBinding" scheme="https"/>
        </protocolMapping>    
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true"/>
      </system.serviceModel>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true"/>
        <!--
            To browse web app root directory during debugging, set the value below to true.
            Set to false before deployment to avoid disclosing web app folder information.
          -->
        <directoryBrowse enabled="false"/>
    
      </system.webServer>
      <system.data>
        <DbProviderFactories>
          <remove invariant="Oracle.ManagedDataAccess.Client"/>
          <add name="ODP.NET, Managed Driver" invariant="Oracle.ManagedDataAccess.Client" description="Oracle Data Provider for .NET, Managed Driver"
            type="Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess, Version=4.122.1.0, Culture=neutral, PublicKeyToken=89b483f429c47342"/>
        </DbProviderFactories>
      </system.data>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <publisherPolicy apply="no"/>
            <assemblyIdentity name="Oracle.ManagedDataAccess" publicKeyToken="89b483f429c47342" culture="neutral"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35"/>
            <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35"/>
            <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35"/>
            <bindingRedirect oldVersion="1.0.0.0-5.2.3.0" newVersion="5.2.3.0"/>
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>
