	internal static IEnumerable<string[]> GetTestDataForSpecificItemType(ItemTypes itemTypeCode)
	{
		return
			DataGetter
				.GetTestData("MyTestData");
				.Where(x => x.ItemTypeCode.Trim() == itemTypeCode.ToString())
				.GroupBy(x => x.AccessionNumber)
				.Where(x => !x.Skip(1).Any())
				.SelectMany(x => x)
				.Select(x => new [] { x.AccessionNumber, x.LoginId });
	}
