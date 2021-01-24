    // check to see if its worth locking in the first place.
    if (!initialized)
    {
        lock (syncRoot)
        {
            // only 1 thread ever enters here at any time.
            if (!initialized)
            {
                Startup.Init<SolrSearchResult>("http://Host:44416/solr");
                initialized = true;
                // no more threads can ever enter here.
            }
        }
    }
