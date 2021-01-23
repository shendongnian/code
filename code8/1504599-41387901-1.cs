    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <namespace name="MyNamespace" />
        <assembly name="MyApp" />
        <container>
          <register type="ILogger" mapTo="TheLogger" />
        </container>
      </unity>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
      </startup>
    </configuration>
