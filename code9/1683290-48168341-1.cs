        <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <location path="." inheritInChildApplications="false">
        <connectionStrings>
          <add name="xxx" connectionString="xxxx" providerName="System.Data.SqlClient"/>
          <add name="xxx" connectionString="xxxx" providerName="System.Data.SqlClient"/>
        </connectionStrings>
      </location>
      <location path="." inheritInChildApplications="false">
        <appSettings>
          <add key="BaseAddress" value="xxxx"/>
        </appSettings>
      </location>
      <system.web>
        <compilation debug="true" targetFramework="4.6.1"/>
        <httpRuntime targetFramework="4.6.1"/>
        <httpModules>
          <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web"/>
        </httpModules>
      </system.web>
      <system.webServer>
        <validation validateIntegratedModeConfiguration="false"/>
        <modules>
          <remove name="ApplicationInsightsWebTracking"/>
          <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web"
            preCondition="managedHandler"/>
        </modules>
      </system.webServer>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="Newtonsoft.Json" publicKeyToken="30ad4fe6b2a6aeed" culture="neutral"/>
            <bindingRedirect oldVersion="0.0.0.0-7.0.0.0" newVersion="7.0.0.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="WebGrease" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
            <bindingRedirect oldVersion="0.0.0.0-1.5.2.14234" newVersion="1.5.2.14234"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="Microsoft.Owin" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
            <bindingRedirect oldVersion="0.0.0.0-3.1.0.0" newVersion="3.1.0.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Web.Http" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
            <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31bf3856ad364e35" culture="neutral"/>
            <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="SimpleInjector" publicKeyToken="984cb50dea722e99" culture="neutral"/>
            <bindingRedirect oldVersion="0.0.0.0-4.0.12.0" newVersion="4.0.12.0"/>
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
      <system.codedom>
        <compilers>
          <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:6 /nowarn:1659;1699;1701"/>
          <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:14 /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+"/>
        </compilers>
      </system.codedom>
      <appSettings>
        <add key="webpages:Version" value="3.0.0.0"/>
        <add key="webpages:Enabled" value="false"/>
        <add key="ClientValidationEnabled" value="true"/>
        <add key="UnobtrusiveJavaScriptEnabled" value="true"/>
      </appSettings>
    </configuration>
