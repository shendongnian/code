    using SolrNet;
    using Microsoft.Practices.ServiceLocation;
    Startup.Init<SOLRModel>("http://localhost:8983/solr/global");
    var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SOLRModel>>();
    var options = new QueryOptions();
    
    options.ExtraParams = new KeyValuePair<string,string>[] {
        new KeyValuePair<string,string>("wt", "xml")
    };
    var results = solr.Query(new SolrQuery("*:*"), options);
