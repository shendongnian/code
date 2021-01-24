			var config = new RealmConfiguration("salt.realm");
			config.SchemaVersion = 1;
			config.MigrationCallback = (migration, oldSchemaVersion) =>
			{
				Settings.UpdateDateRecommendationsUtc = DateTime.MinValue;
				migration.NewRealm.RemoveAll<Recommendation>();
				migration.NewRealm.RemoveAll<RecDataString>();
				migration.NewRealm.RemoveAll<RecChart>();
				migration.NewRealm.RemoveAll<RecSummary>();
				migration.NewRealm.RemoveAll<RecTickerSymbol>();
			};
