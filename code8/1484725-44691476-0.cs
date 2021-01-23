    public ElasticClient GetClient()
        {
            if (this.client == null)
            {
                settings = new ConnectionSettings(nodeUri).DefaultIndex(indexName);
                this.client = new ElasticClient(settings);
            }
    
            return client;
        }
