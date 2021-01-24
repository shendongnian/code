    Install MySql for VS 1.2.9
    Install MySql Connector 6.8.3
    
    Add these Nuget Packages To your Project:
    
    EntityFramework    //  6.4
    Mysql.Data      //  6.8.8
    Mysql.Data.Entities   // 6.8.3  
    Mysql.Web  //   6.8.8
    
    in Solution Explorer edit App.config:( Add or Replace):
    
        <entityFramework>
        <defaultConnectionFactory type="MySql.Data.Entity.MySqlConnectionFactory, MySql.Data.Entity.EF6" />
        <providers>
        <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6" />
        </providers>
        </entityFramework>
    
    
    
        rebiuld and nothing more 
