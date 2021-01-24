    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;
    
    DataSource dataSource = CreateDataSource(sqlQuery, collectionName, indexName, dataSourceName, dataSourceConnectionString);
    AzureOperationResponse<DataSource> operation = await client.DataSources.CreateOrUpdateWithHttpMessagesAsync(dataSource);
    
    private DataSource GetDataSource(string sqlQuery, string collectionName, string indexName, string dataSourceName, string dataSourceConnectionString)
    {
    	DataSource dataSource = new DataSource();
    	dataSource.Name = dataSourceName;
    	dataSource.Container = GetDataSourceContainer(sqlQuery, collectionName);
    	dataSource.Credentials = new DataSourceCredentials(dataSourceConnectionString);
    	dataSource.Type = "documentdb";
    	return dataSource;
    }		
    
    private DataContainer GetDataSourceContainer(string sqlQuery, string collectionName)
    {
    	DataContainer container = new DataContainer();
    	container.Query = sqlQuery;
    	container.Name = collectionName;
    	return container;
    }
