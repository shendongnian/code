	public static class Extensions
	{
		public static IEnumerable<InputModel> Map(this DataTable instance)
		{
			foreach (DataRow row in instance.Rows)
			{
				yield return new InputModel
				{
					legacy = (string)row[0],
					subid  = (string)row[1],
					converted  = (string)row[2],
					licPart = (string)row[3],
					count = (string)row[4],
				};
			}
		}
	}
