    <system.web>
        <pages validateRequest="true" ...>    
            <namespaces>
               <add namespace="System.Web.Mvc" />
               ...
            </namespaces>
        </pages>
    </system.web>
    ...
    <runtime>
        <dependentAssembly>
            <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35" />
            <bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="5.0.0.0" />
        </dependentAssembly>
    </runtime>
