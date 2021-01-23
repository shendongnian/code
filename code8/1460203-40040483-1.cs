    <system.web>
    <httpHandlers>
      <add path="Reserved.ReportViewerWebControl.axd" verb="*" type="Microsoft.Reporting.WebForms.HttpHandler, Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
        validate="false" />
    </httpHandlers>
    <assemblies>
        <add assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"/>
        <add assembly="Microsoft.ReportViewer.Common, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"/>
        <add assembly="Microsoft.Build.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"/>
    </assemblies>
    <buildProviders>
        <remove extension=".rdlc" />
        <add extension=".rdlc" type="Microsoft.Reporting.RdlBuildProvider, Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" />
    </buildProviders>
    </system.web>
   
    <system.webServer> 
      <handlers>
      <remove name="ReportViewerWebControlHandler"/>
      <add name="Reenter code hereportViewerWebControlHandler" preCondition="integratedMode" verb="*" path="Reserved.ReportViewerWebControl.axd" type="Microsoft.Reporting.WebForms.HttpHandler, Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" />
      </handlers>
     </system.webServer>
