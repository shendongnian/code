			string query = "SELECT * FROM MyIngresTable WHERE MyColumn >= ? and OtherColumn = ?";
			IDbParametersBuilder builder = CreateDbParametersBuilder();
			builder.Create().Type(DbType.Int32).Value(10);
			builder.Create().Type(DbType.String).Size(4).Value("test");
			IList<YourModelType> data = AdoTemplate.QueryWithRowMapper(
				CommandType.Text,
				query,
				new YourRowMapper<YourModelType>(),
				builder.GetParameters()
			);
