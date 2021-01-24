    migration.NewRealm.Write(() => 
    { 
        migration.NewRealm.RemoveAll("RecDataString");
        migration.NewRealm.RemoveAll("RecChart");
        migration.NewRealm.RemoveAll("RecSummary");
        migration.NewRealm.RemoveAll("RecTickerSymbol");
        migration.NewRealm.RemoveAll("Recommendation");
    });
    await UpdateRecommendationFromYourWebApi();
