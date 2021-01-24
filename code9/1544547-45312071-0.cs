    <?xml version="1.0"?>
    <configuration>
      <system.web>
        <compilation>
          <assemblies>
            <add assembly="System.DirectoryServices.AccountManagement, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
          </assemblies>
        </compilation>
      </system.web>
      <system.web.webPages.razor>
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.DirectoryServices.AccountManagement" />
          </namespaces>
        </pages>
      </system.web.webPages.razor>
    </configuration>
