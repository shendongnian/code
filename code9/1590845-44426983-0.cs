     <connectionStrings >
    <add
         name="myConnectionString" 
         connectionString="Server=myServerAddress;Database=myDataBase;User ID=myUsername;Password=myPassword;Trusted_Connection=False;"
         providerName="System.Data.SqlClient"/>
    </connectionStrings>
    and where you want to setup the connection variable:
    SqlConnection con = new SqlConnection(
    WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
