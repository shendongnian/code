    <configuration>
      <appSettings>
        <add key="aspnet:UseTaskFriendlySynchronizationContext" value="true" />
        <add key="ClientSettingsProvider.ServiceUri" value="" />
      </appSettings>
      <system.web>
        <compilation debug="true" />
        <membership defaultProvider="XYZProvider">
          <providers>
            <add name="XYZshipProvider" type="System.Web.ClientServices.Providers.XYZProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf35678563123ad364e35" serviceUri="" />
          </providers>
        </membership>
        <roleManager defaultProvider="ClientRoleProvider" enabled="true">
          <providers>
            <add name="ClientRoleProvider" type="System.Web.ClientServices.Providers.ClientRoleProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856564ad364e35" serviceUri="" cacheTimeout="86400" />
          </providers>
        </roleManager>
      </system.web>
      <!-- When deploying the service library project, the content of the config file must be added to the host's 
      app.config file. System.Configuration does not support config files for libraries. -->
      <system.serviceModel>
    <behaviors>
      <endpointBehaviors>
        <behavior name="protoEndpointBehavior">
          <protobuf/>
        </behavior>
      </endpointBehaviors>
      <serviceBehaviors>
        <behavior>
          <serviceMetadata httpGetEnabled="false" httpsGetEnabled="false"/>
          <serviceDebug includeExceptionDetailInFaults="true"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
 
    <bindings>
      <netNamedPipeBinding>
        <binding name="namedPipeBinding" receiveTimeout="00:10:00" sendTimeout="0:10:00" maxBufferSize="2147483647" maxReceivedMessageSize="2147483647" />
      </netNamedPipeBinding>
    </bindings>
 
    <services>
      <service name="WcfProtobufService.SimpleService">
        <endpoint binding="netNamedPipeBinding" bindingConfiguration="namedPipeBinding" contract="WcfProtobufService.ISimpleService" behaviorConfiguration="protoEndpointBehavior"/>
        <endpoint address="mex" binding="mexNamedPipeBinding" contract="IMetadataExchange" />
        <host>
          <baseAddresses>
            <add baseAddress="net.pipe://localhost/console/SimpleService.svc"/>
          </baseAddresses>
        </host>
      </service>
    </services>
 
    <extensions>
      <behaviorExtensions>
        <add name="protobuf" type="ProtoBuf.ServiceModel.ProtoBehaviorExtension, protobuf-net, Version=2.0.0.668, Culture=neutral, PublicKeyToken=257b51d87d2e4d67"/>
      </behaviorExtensions>
    </extensions>
