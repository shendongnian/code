        <service name="App.Services.Service1" behaviorConfiguration="mexendpoint">
            <endpoint address="" binding="basicHttpBinding" contract="App.Services.Interfaces.IService1">
              <identity>
                <dns value="localhost" />
              </identity>
            </endpoint>
            <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:8733/Design_Time_Addresses/App.Services/Service1/" />
              </baseAddresses>
            </host>
          </service>
    <behaviors>
      <serviceBehaviors>  
        <behavior name="mexendpoint">
          <serviceMetadata httpGetEnabled="true"/>
          <serviceDebug includeExceptionDetailInFaults="true"/>
        </behavior>
         </serviceBehaviors>
    </behaviors>
    </system.serviceModel>
