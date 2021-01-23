  	var resultsFromDb = (from esm in _uow.Web_SyncMatchesRepository.GetAll()
										  join lup in (_uow.Web_LookupsRepository.GetAll().Where(a => a.RV_DOMAIN == "match_method")) on esm.MATCH_METHOD equals lup.LOOKUP_KEY
										  where esm.SUBMISSION_ID == "28105" select new {esm = esm, lup = lup, peopleEntity = peopleEntity}).ToList(); // Here we break the linq to sql query
    // Then run a select query on the above collection to get what we want.  
	WebSyncDetailObject  = resultsFromDb.Select(r => new WebSyncDetailEntity {WebSyncMatch = r.esm, WebLookups = r.lup, People = r.peopleEntity }).ToList();
