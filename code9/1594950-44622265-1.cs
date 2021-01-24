	internal static IEnumerable<string[]> GetTestDataForSpecificItemType(ItemTypes itemTypeCode)
	{
		return
			DataGetter
				.GetTestData("MyTestData");
				.Where(x => x.ItemTypeCode.Trim() == itemTypeCode.ToString())
				.GroupBy(x => x.AccessionNumber)
				.SelectMany(x => x.Take(1))
				.Select(x => new [] { x.AccessionNumber, x.LoginId });
	}
