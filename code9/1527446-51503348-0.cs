    <wsHttpBinding>
       <binding name = "WCFTest_Config">
          <security mode = "TransportWithMessageCredential">
             <transport clientCredentialType = "None" proxyCredentialType = "None" realm = "" />
             <message clientCredentialType = "UserName" />
          </security>
       </binding>
    </wsHttpBinding>
