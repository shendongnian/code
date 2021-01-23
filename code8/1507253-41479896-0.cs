    <connectionStrings>
        <!-- SQL Express connection string -->
        <add name="KeepitrememberConnection"
        connectionString="Data Source=mypcname\SQLEXPRESS;Initial Catalog=Keepitremember;
        AttachDbFilename=|DataDirectory|Keepitremember.mdf;Integrated Security=True;
        User Instance=True"
        providerName="System.Data.SqlClient" />
    
        <!-- EF connection string -->
        <add name="KeepitrememberEntities" 
        connectionString="metadata=res://*/EDM.csdl|res://*/EDM.ssdl|res://*/EDM.msl;
        provider=System.Data.SqlClient;provider connection string=&quot;
        data source=mypcname\SQLEXPRESS;initial catalog=Keepitremember;
        integrated security=True;MultipleActiveResultSets=True App=EntityFramework&quot;" 
        providerName="System.Data.EntityClient" />
    </connectionStrings>
