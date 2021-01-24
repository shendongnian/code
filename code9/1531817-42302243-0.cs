			var config = new RealmConfiguration("salt.realm");
			config.SchemaVersion = 1;
			config.MigrationCallback = (migration, oldSchemaVersion) =>
			{
				Settings.UpdateDateRecommendationsUtc = DateTime.MinValue;
				var query = migration.NewRealm.All<Recommendation>();
				migration.NewRealm.RemoveRange(query);
				var query1 = migration.NewRealm.All<RecDataString>();
				migration.NewRealm.RemoveRange(query1);
				var query2 = migration.NewRealm.All<RecChart>();
				migration.NewRealm.RemoveRange(query2);
				var query3 = migration.NewRealm.All<RecSummary>();
				migration.NewRealm.RemoveRange(query3);
				var query4 = migration.NewRealm.All<RecTickerSymbol>();
				migration.NewRealm.RemoveRange(query4);
			};
