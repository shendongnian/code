    <system.serviceModel>
        <behaviors>
          <serviceBehaviors>
            <behavior name="">
              <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
        <bindings>
          <basicHttpBinding>
            <binding name="BasicHttpBinding_MyWCFInterface"  maxBufferSize="2147483647" maxReceivedMessageSize="2147483647" />
          </basicHttpBinding>
        </bindings>
        <services>
          <service name="MyProject.MyWCFClass" >
            <endpoint address=""
                      binding="basicHttpBinding"
                      bindingConfiguration="BasicHttpBinding_MyWCFInterface"
                      contract="MyProject.MyWCFInterface"/>
          </service>
        </services>
    </system.serviceModel>
