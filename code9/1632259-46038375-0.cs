	public DeviationCalculationResult Get(decimal presentWidth, decimal presentAspectRatio, string presentRimSize, int maxDeviation)
	{
		using (var context = new OminiTireEntities())
		{
			var reader = context.Database.Connection.QueryMultiple("[Tabel].[DeviationCalculation]",
				new
				{
					PresentWidth = presentWidth,
					PresentAspectRatio = presentAspectRatio,
					PresentInches = presentRimSize,
					MaxDeviation = maxDeviation
				}, commandType: CommandType.StoredProcedure);
			var first = reader.Read<First>().ToList().First();
			var second = reader.Read<Second>().ToList().First();
			var third = reader.Read<Third>().ToList().First();
			//...and so on...
			return new DeviationCalculationResult
			{
				First = first,
				Second = second,
				Third = third,
				//...
			};
		}
	}
