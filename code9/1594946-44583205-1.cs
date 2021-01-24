    internal static IEnumerable<string[]> GetTestDataForSpecificItemType(ItemTypes itemTypeCode)
    {
        IEnumerable<StudentAssessmentTestData> data = DataGetter.GetTestData("MyTestData");
        data = data.Where(x => x.ItemTypeCode.Trim() == itemTypeCode.ToString());
        var z = data.DistinctBy(x => x.AccessionNumber);
        foreach (var record in z)
        {
            yield return new[] { record.AccessionNumber, record.LoginId };
        }
    }
