      <system.serviceModel>
        <extensions>
          <behaviorExtensions>
            <add name="CustomBehaviorExtension" type="MyProj.CustomBehaviorExtensionElement, MyProj, Version=1.0.0.0, Culture=neutral" />
          </behaviorExtensions>
        </extensions>
        <behaviors>
          <endpointBehaviors>
            <behavior>
              <CustomBehaviorExtension />
            </behavior>
          </endpointBehaviors>
          <serviceBehaviors>
            <behavior>
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="false" />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <services>
          <service name="MyProj.MyService">
            <endpoint binding="mexHttpBinding" address="mex" contract="IMetadataExchange"></endpoint>
            <endpoint name="MyServiceEndpoint" binding="basicHttpBinding" contract="MyProjServiceContract"></endpoint>
          </service>
        </services>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
