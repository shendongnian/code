    <location path="scripts">
        <system.webServer>
          <httpProtocol>
            <customHeaders>
              <remove name="Cache-Control" />
              <add name="Cache-Control" value="public" />
            </customHeaders>
          </httpProtocol>
          <staticContent>
            <clientCache cacheControlMode="UseMaxAge" cacheControlMaxAge="20.00:00:00" />
          </staticContent>
        </system.webServer>
    </location>
