    AlgoliaClient searchClient = new AlgoliaClient("x", "x");
    Index purgeIndex = searchClient.InitIndex(paramIndex);
    Query purgeQuery = new Query("");
    JArray facetFilters = new JArray();
    JToken facetToken = JToken.Parse("['" + paramFacetName + ":" + paramFacetValue + "']");
    facetFilters.Add(facetToken);
    purgeQuery.SetFacetFilters(facetFilters);
    purgeIndex.DeleteByQuery(purgeQuery);
