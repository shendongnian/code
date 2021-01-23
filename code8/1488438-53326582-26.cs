    public class ConnectionStringWrapperDotNetClassicRetriever : IConnectionStringWrapperRetriever
    {
        public ConnectionStringWrapper RetrieveConnectionStringWrapper()
        {
            ConnectionStringWrapper returnItem = new ConnectionStringWrapper();
            foreach(ConnectionStringSettings css in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                ConnectionStringEntry cse = new ConnectionStringEntry(css.Name, css.ConnectionString, css.ProviderName);
                returnItem.ConnectionStringEntries.Add(cse);
            }
            if(returnItem.ConnectionStringEntries.Count == 1)
            {
                /* if there is only one, set the default name to that one */
                returnItem.DefaultConnectionStringName = returnItem.ConnectionStringEntries.First().Name;
            }
            else
            {
                /*
                <packages>
                  <package id="EnterpriseLibrary.Common" version="6.0.1304.0" targetFramework="net45" />
                  <package id="EnterpriseLibrary.Data" version="6.0.1304.0" targetFramework="net45" />
                </packages>                 
                 */
                /* using Microsoft.Practices.EnterpriseLibrary.Data.Configuration; */
                /* You can write you own way to handle a default database, or piggyback off of EnterpriseLibrary.  You don't necessarily have to use EnterpriseLibrary.Data, you are simply piggybacking on their xml/configuration setup */
                DatabaseSettings dbSettings = (DatabaseSettings)ConfigurationManager.GetSection("dataConfiguration");
                returnItem.DefaultConnectionStringName = dbSettings.DefaultDatabase;
            }
            return returnItem;
        }
    }
