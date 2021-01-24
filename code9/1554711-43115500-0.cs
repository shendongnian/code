	DocumentClient _documentDbclient;
	
	// Database configuration
	static readonly string DocumentDbKeyConfig = "3dzS7T3a8lgEblkEnzSsdfasdfasf2omI1cp7==";
	static readonly string DocumentDbEndPointConfig = "https://your-docdb.documents.azure.com:443/";
	static readonly string DocumentDbDatabaseNameConfig = "your-database-name";
	
	void Main()
	{
		
		string collectionName = "TestCollection";
		
		Uri uri = UriFactory.CreateDocumentCollectionUri(DocumentDbDatabaseNameConfig, collectionName);
		InitializeDocumentDbAsync(DocumentDbDatabaseNameConfig).ConfigureAwait(false);
	
		createDocumentCollectionIfNotExistAsync(DocumentDbDatabaseNameConfig, collectionName).ConfigureAwait(false);
	
		DocumentCollection collection = _documentDbclient.ReadDocumentCollectionAsync(uri).Result;
		var query = _documentDbclient.CreateDocumentQuery(uri);
		var queryList = query.ToList();
	
		int index = 0;
		int count = 50; // number of item to fetch at a time
		while (true)
		{
			var result = queryList.Skip(index * count).Take(count);
	
			if (!result.Any())
			{
				// end iterating.
				return;
			}
	
			foreach (Document element in result)
			{
				JObject j = (dynamic)element;
				j["Type"] = 8; // edit value.
	
				var upsertedResult = _documentDbclient.UpsertDocumentAsync(uri, j, null, true).Result;
			}
			++index;
		}
	}
	
	public async Task InitializeDocumentDbAsync(string databaseName)
	{
		// Create a new instance of the DocumentClient
		_documentDbclient = new DocumentClient(
			new Uri(DocumentDbEndPointConfig), DocumentDbKeyConfig);
		// Check if the database FamilyDB does not exist
	
		try
		{
			await _documentDbclient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseName));
		}
		catch (DocumentClientException de)
		{
			// If the database does not exist, create a new database
			if (de.StatusCode == HttpStatusCode.NotFound)
			{
				await _documentDbclient.CreateDatabaseAsync(new Database { Id = databaseName });
			}
			else
			{
				throw;
			}
		}
		catch (Exception e)
		{
			throw;
		}
	}
	
	private async Task createDocumentCollectionIfNotExistAsync(string databaseName, string collectionName)
	{
		try
		{
			await
				_documentDbclient.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName));
		}
		catch (DocumentClientException de)
		{
			// not exist
			throw;
		}
		catch (Exception e)
		{
			// do nothing.
		}
	}
