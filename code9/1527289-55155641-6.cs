      <system.webServer>
        <modules>
          <add name="HeadersModule " type="MyNamespace.Modules.HeadersModule " />
        </modules>
        <httpProtocol>
          <customHeaders>
            <remove name="X-Powered-By" />
            <remove name="Server" />
            <remove name="X-AspNet-Version" />
            <remove name="X-AspNetMvc-Version" />
          </customHeaders>
          <redirectHeaders>
            <clear />
          </redirectHeaders>
        </httpProtocol>
      </system.webServer>
    
