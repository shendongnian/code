	var seed = new List<OutputModel>();
	var outcome = records
		.Aggregate(seed, (results, current) =>
		{
			var query = from result in results
						where result.legacy == current.legacy
							&& (result.list == null
								|| !result.list.Contains(current.converted))
						select result;
			var output = query.FirstOrDefault();
			if (output == null)
			{
				output = new OutputModel
				{
					legacy = current.legacy,
					subid = current.subid,
					licPart = current.licPart,
					list = new List<string>
					{
						current.converted
					}
				};
				results.Add(output);
			}
			else
			{
				output.list.Add(current.converted);
			}
			return results;
		});
