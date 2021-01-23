    private void btnTest_Click(object sender, EventArgs e)
    {
        // Load sample database into db (db is actually List<DbPerson>)
        var db = GenerateTestDb();
        // Create filter looking for FirstName is "John"
        var filterValues = new DbPersonFilter
        {
            FirstName = "John",
        };
        // Build PredicateParser which it used to parse predicates inside ExpressionExtensions. 
        var predicateParser = new PredicateParser();
        // Build predicate...
        var predicate1 = PredicateBuilder.New(ExpressionExtensions.BuildPredicate<DbPerson>(filterValues, predicateParser, true));
        // And search for items...
        var items1 = db.AsQueryable().AsExpandable().Where(predicate1).ToList();
        // Create filter to look for items where Id is between 1 and 2
        filterValues = new DbPersonFilter
        {
            Id = "1-2",
        };
        // Build predicate...
        var predicate2 = PredicateBuilder.New(ExpressionExtensions.BuildPredicate<DbPerson>(filterValues, predicateParser, true));
        // And search for items...
        var items2 = db.AsQueryable().AsExpandable().Where(predicate2).ToList();
        // Create filter to look for items where Age is 44
        filterValues = new DbPersonFilter
        {
            Age = "44",
        };
        // Build predicate...
        var predicate3 = PredicateBuilder.New(ExpressionExtensions.BuildPredicate<DbPerson>(filterValues, predicateParser, true));
        // And search for items...
        var items3 = db.AsQueryable().AsExpandable().Where(predicate3).ToList();
    }
